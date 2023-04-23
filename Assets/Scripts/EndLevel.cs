using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EndLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameStatusText;
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    [SerializeField] private TextMeshProUGUI achievementsUnlockedText;
    [SerializeField] private TextMeshProUGUI achievementsLockedText;
    [SerializeField] private List<Achievements> _achievementsList;

    private void Start()
    {
        if (PlayerPrefs.GetInt(TrigerValueName) == TrigerValue)
        {
            gameStatusText.text = "Вы прошли уровень";
        }
        else
        {
            gameStatusText.text = "Вы НЕ прошли уровень";
        }
        foreach (var achiv in _achievementsList)
        {
            if (PlayerPrefs.GetInt(achiv.TrigerValueName) == achiv.TrigerValue)
            {
                achievementsUnlockedText.text += "🗸"+achiv.Title+'\n';
            }
            else
            {
                achievementsLockedText.text += "✗"+achiv.Title+'\n';
            }
        }
    }
}

[Serializable]
public struct Achievements
{
    public string Title;
    public string TrigerValueName;
    public int TrigerValue;
}
