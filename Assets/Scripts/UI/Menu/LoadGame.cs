using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class Button : MonoBehaviour
    {
        public void OnClick()
        {
            Fade.sceneEnd = true;
            Debug.Log("OnClick");
            Load("cuka");
        }

        public void Load(string name)
        {
            SceneManager.LoadScene("Levels");

        }

        public void Start()
        {
            Debug.Log("OnClickStart");
        }

        public void Update()
        {
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}