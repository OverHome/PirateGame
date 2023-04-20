using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeing : MonoBehaviour
{
    private Animator _animation;
    private bool isFadeing;
    private GoInOut _go;
    
    void Start()
    {
        _animation = GetComponent<Animator>();
        isFadeing = _animation.GetBool("fade");
        gameObject.SetActive(false);
        
    }

    public void FadeIn(GoInOut goInOut)
    {
        if (isFadeing) return;
        _go = goInOut;
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
        _go.OnFafeIn();
    }
    
    public void HendingOut()
    {
        gameObject.SetActive(false);
        _go.OnFafeOut();
    }
}

