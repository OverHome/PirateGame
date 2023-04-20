using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void GetStart(Sprite avatar, string name, string tagTame, List<TextAsset> data)
    {
        NodeIndex = 0;
        Avatar.sprite = avatar;
        Name.text = name;
        Text.text = "";
        Data = data;
        _dialogue = Dialogue.Load(Data[PlayerPrefs.GetInt(tagTame)]);
        SetNode();
    }

    public void SetNode()
    {
        Text.text = _dialogue.nodes[NodeIndex].Npctext.Replace("\\n", "\n");
        int[] answers = GetAnswers().ToArray();
        Answer1Text.text = _dialogue.nodes[NodeIndex].answers[answers[0]].text;
        if (answers.Length >= 2)
        {
            Answer2Text.text = _dialogue.nodes[NodeIndex].answers[answers[1]].text;
            Answer2.gameObject.SetActive(true);
        }
        else
        {
            Answer2.gameObject.SetActive(false);
        }
    }

    public List<int> GetAnswers()
    {
        List<int> answers = new();
        for (int i = 0; i < _dialogue.nodes[NodeIndex].answers.Length; i++)
        {
            Answer answer = _dialogue.nodes[NodeIndex].answers[i];
            bool isAccess = true;
            foreach (var param in answer.need.EmptyIfNull())
            {
                if (PlayerPrefs.GetInt(param.param, 0) != param.value)
                {
                    isAccess = false;
                    break;
                }
                
            }

            if (isAccess)
            {
                answers.Add(i);
            }
        }

        return answers;
    }

    public void SelectAnswer(int answer)
    {
        foreach (var param in _dialogue.nodes[NodeIndex].answers[answer].set.EmptyIfNull())
        {
            PlayerPrefs.SetInt(param.param, param.value);
        }
        
        if (_dialogue.nodes[NodeIndex].answers[answer].end == "true")
        {
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

public static class EnumerableExtensions {
    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source) =>
        source != null ? source : Enumerable.Empty<T>();
}
