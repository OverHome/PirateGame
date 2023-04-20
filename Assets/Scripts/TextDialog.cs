using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextDialog : MonoBehaviour
{
    private Canvas _canvas;
    [SerializeField] private Kapitan _kapitan;
    [SerializeField] private Image Avatar;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private List<TextAsset> Data;
    [SerializeField] private Button Answer1;
    [SerializeField] private Button Answer2;
    private TextMeshProUGUI Answer1Text;
    private TextMeshProUGUI Answer2Text;

    private Dialogue _dialogue;
    private int NodeIndex;
    private void Start()
    {
        _canvas = GetComponentInParent<Canvas>(true);
        Answer1Text = Answer1.GetComponentInChildren<TextMeshProUGUI>();
        Answer2Text = Answer2.GetComponentInChildren<TextMeshProUGUI>();
        Hide();
    }

    public void GetStart(Sprite avatar, string name, List<TextAsset> data)
    {
        NodeIndex = 0;
        Avatar.sprite = avatar;
        Name.text = name;
        Text.text = "";
        Data = data;
        _dialogue = Dialogue.Load(Data[PlayerPrefs.GetInt(name)]);
        SetNode();
    }

    public void SetNode()
    {
        Text.text = _dialogue.nodes[NodeIndex].Npctext;
        Answer1Text.text = _dialogue.nodes[NodeIndex].answers[0].text.Replace("\\n", "\n");;
        if (_dialogue.nodes[NodeIndex].answers.Length == 2)
        {
            Answer2Text.text = _dialogue.nodes[NodeIndex].answers[1].text;
            Answer2.gameObject.SetActive(true);
        }
        else
        {
            Answer2.gameObject.SetActive(false);
        }
    }

    public void SelectAnswer(int answer)
    {
        if (_dialogue.nodes[NodeIndex].answers[answer].end == "true")
        {
            PlayerPrefs.SetInt(Name.text, _dialogue.nodes[NodeIndex].answers[answer].personalCount);
            _kapitan.EndDialog();
        }
        else
        {
            NodeIndex = _dialogue.nodes[NodeIndex].answers[answer].nextNode;
            SetNode();
        }
    }

    public void Hide()
    {
        _canvas.gameObject.SetActive(false);
    }
    
    public void Show()
    {
        _canvas.gameObject.SetActive(true);
    }
}
