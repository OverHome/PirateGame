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
        }

        public void Load(string name)
        {
            SceneManager.LoadScene("Island_1");

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