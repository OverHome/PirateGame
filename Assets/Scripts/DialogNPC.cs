using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class DialogNPC : MonoBehaviour, IPointerClickHandler
{
    private Kapitan _kapitan;
    private bool _wait;

    [SerializeField] public List<TextAsset> Dialogs;
    [SerializeField] public string Name;
    [SerializeField] public string TagName;
    [SerializeField] public bool Reversed = true;
    
    public Sprite Avatar;
    
    private void Start()
    {
        _kapitan = GameObject.Find("kapitan").GetComponent<Kapitan>();
        _wait = false;
        Avatar = GetComponent<SpriteRenderer>().sprite;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        print("dsfsdf");
        if (!_kapitan.PlayerIsBusy)
        {
            _kapitan.SetMoveTo(gameObject.transform.position);
            _wait = true; 
        }
        
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (_wait)
        {
            StartDialog();
        }
    }

    public void StartDialog()
    {
        if (Reversed) gameObject.GetComponent<SpriteRenderer>().flipX = !_kapitan.GetComponent<SpriteRenderer>().flipX;

        _kapitan.StartDialog(Avatar, Name, TagName, Dialogs);
        _wait = false;
    }
}
