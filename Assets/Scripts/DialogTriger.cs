using System;
using UnityEngine;

public class DialogTriger : MonoBehaviour
{
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    private DialogNPC _dialog;
    private bool IsUse;
    
    private void Start()
    {
        _dialog = GetComponent<DialogNPC>();
        IsUse = false;
    }
    
    private void Update()
    {
        if (!IsUse)
        {
            if (PlayerPrefs.GetInt(TrigerValueName) == TrigerValue)
            {
                _dialog.StartDialog();
                IsUse = true;
            }
        }
    }
}
