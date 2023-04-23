using System;
using UnityEngine;


public class Pointer : MonoBehaviour
{
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    
    [SerializeField] public string FinTrigerValueName;
    [SerializeField] public int FinTrigerValue;

    private SpriteRenderer sr;
    private bool Ispok;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Ispok = false;
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(FinTrigerValueName) == FinTrigerValue)
        {
            Ispok = false;
        }
        else if(PlayerPrefs.GetInt(TrigerValueName) == TrigerValue)
        {
            Ispok = true;
        }

        if (Ispok)
        {
            sr.color = new Color(255, 255, 255, 255);
        }
        else
        {
            sr.color = new Color(255, 255, 255, 0);
        }


    }
    
}
