using UnityEngine;


public class TriggerSwitchRotationDialog : MonoBehaviour
{
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    
    private bool IsUse;
    private DialogNPC _dialog;
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
                _dialog.Reversed = !_dialog.Reversed; 
                IsUse = true;
            }
        }
    }
}
