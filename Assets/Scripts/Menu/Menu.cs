using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour, IFeading
{
    [SerializeField] private Fadeing _fadeing;

    private string _lvlName;
    
    public void LoadLvl(string name)
    {
        _lvlName = name;
        _fadeing.FadeIn(this);
    }

    public void OnFafeIn()
    {
        SceneManager.LoadScene(_lvlName);
        _fadeing.FadeOut();
    }
    public void OnFafeOut()
    {
       
    }
}
