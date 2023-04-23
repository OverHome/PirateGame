using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeing : MonoBehaviour
{
    private Animator _animation;
    private bool isFadeing;
    private GoInOut _go;
    private TrigerLoadNext _trigerLoadNext;
    
    void Start()
    {
        _animation = GetComponent<Animator>();
        isFadeing = _animation.GetBool("fade");
        gameObject.SetActive(false);
        _trigerLoadNext = null;
    }

    public void FadeIn(GoInOut goInOut)
    {
        if (isFadeing) return;
        _go = goInOut;
        gameObject.SetActive(true);
        isFadeing = !isFadeing;
        _animation.SetBool("fade", isFadeing);
    }
    public void FadeIn(TrigerLoadNext trigerLoadNext)
    {
        if (isFadeing) return;
        _trigerLoadNext = trigerLoadNext;
        gameObject.SetActive(true);
        isFadeing = !isFadeing;
        _animation.SetBool("fade", isFadeing);
    }
    
    public void FadeOut()
    {
        if (!isFadeing) return;
        gameObject.SetActive(true);
        isFadeing = !isFadeing;
        _animation.SetBool("fade", isFadeing);
    }

    public void HendingIn()
    {
        if (_trigerLoadNext==null)
        {
            _go.OnFafeIn();
        }
        else
        {
            _trigerLoadNext.OnFafeIn();
        }
    }
    
    public void HendingOut()
    {
        gameObject.SetActive(false);
        
        if (_trigerLoadNext==null)
        {
            _go.OnFafeOut();
        }
        else
        {
            _trigerLoadNext.OnFafeOut();
        }
        
    }
}

