using System;
using UnityEngine;

public class TrigerAnimation : MonoBehaviour
{
    [SerializeField] public string TrigerValueName;
    [SerializeField] public string NextTrigerValueName;
    [SerializeField] public int TrigerValue;
    [SerializeField] public int NextTrigerValue;

    private bool IsUse;
    private Animator _animator;
    private void Start()
    {
        IsUse = false;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!IsUse)
        {
            if (PlayerPrefs.GetInt(TrigerValueName) == TrigerValue)
            {
                _animator.SetBool(TrigerValueName, true);
                IsUse = true;
            }
           
        }
    }

    public void OnAnimatorStop()
    {
        PlayerPrefs.SetInt(NextTrigerValueName, NextTrigerValue);
    }
}
