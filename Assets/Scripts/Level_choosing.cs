using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Level
{
    public string LevelName { get; set; }
    
    public string StartSceneName { get; set; }

    public bool IsAvalible { get; set; }

}

public class Level_choosing : MonoBehaviour
{
    public List<Level> Levels = new List<Level>()
    {
        new Level()
        {
            LevelName = "Island_1",
            StartSceneName = "island 1",
            IsAvalible = true
        },
        new Level()
        {
            LevelName = "island 2",
            StartSceneName = "island 2",
            IsAvalible = false
        },
        new Level()
        {
            LevelName = "island 3",
            StartSceneName = "island 3",
            IsAvalible = false
        },
        new Level()
        {
        LevelName = "Main Menu",
        StartSceneName = "Main Menu",
        IsAvalible = true
    }
    };
    // Start is called before the first frame update

    public void OnClick(string buttonName)
    {
        foreach (var level in Levels)
        {
            if (level.LevelName == buttonName && level.IsAvalible)
            {
                Application.LoadLevel(level.LevelName);
            }
        }
    }
}
