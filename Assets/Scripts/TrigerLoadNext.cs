using UnityEngine;
using UnityEngine.SceneManagement;


public class TrigerLoadNext : MonoBehaviour, IFeading
{
    [SerializeField] public string TrigerValueName;
    [SerializeField] public int TrigerValue;
    [SerializeField] private Fadeing _fadeing;
    [SerializeField] public string LvlName;
    
    private bool IsUse;
    private void Start()
    {
        IsUse = false;
    }

    private void Update()
    {
        if (!IsUse)
        {
            if (PlayerPrefs.GetInt(TrigerValueName) == TrigerValue)
            {
                _fadeing.FadeIn(this);
                
                IsUse = true;
            }
        }
    }
    
    public void OnFafeIn()
    {
        SceneManager.LoadScene(LvlName);
        _fadeing.FadeOut();
    }
    public void OnFafeOut()
    {
       
    }
}
