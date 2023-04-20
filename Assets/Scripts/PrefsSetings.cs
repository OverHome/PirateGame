using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PrefsDelete : MonoBehaviour
{
    [SerializeField] private List<PrefItem> list = new();
    [SerializeField] private bool CleanUp;
    [SerializeField] private bool UseList;
    void Start()
    {
        if(CleanUp) PlayerPrefs.DeleteAll();
        if (UseList)
        {
            foreach (var pref in list) 
            {
                PlayerPrefs.SetInt(pref.pref, pref.value);
            }
        }
    }

}

[Serializable]
public struct PrefItem
{
    [SerializeField] public string pref;

    [SerializeField] public int value;
}
