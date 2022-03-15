using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    [SerializeField] private int nextScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void OpenLink()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=bUIh2cOOSOQ");
    }
}
