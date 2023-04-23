using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameStatusText;
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    [SerializeField] private TextMeshProUGUI achievementsUnlockedText;
    [SerializeField] private TextMeshProUGUI achievementsLockedText;
    [SerializeField] private List<Achievements> _achievementsList;

    private string LvlName;

    private void Start()
    {
        if (PlayerPrefs.GetInt(TrigerValueName) == TrigerValue)
        {
            gameStatusText.text = "Вы прошли уровень!";
        }
        else
        {
            gameStatusText.text = "Вы НЕ прошли уровень!";
        }
        foreach (var achiv in _achievementsList)
        {
            if (PlayerPrefs.GetInt(achiv.TrigerValueName) == achiv.TrigerValue)
            {
                achievementsUnlockedText.text += "+"+achiv.Title+'\n';
            }
            else
            {
                achievementsLockedText.text += "-"+achiv.Title+'\n';
            }
        }
    }

    public void SetP(string name)
    {
        PlayerPrefs.SetInt(name, 1);
    }
}

[Serializable]
public struct Achievements
{
    public string Title;
    public string TrigerValueName;
    public int TrigerValue;
}
