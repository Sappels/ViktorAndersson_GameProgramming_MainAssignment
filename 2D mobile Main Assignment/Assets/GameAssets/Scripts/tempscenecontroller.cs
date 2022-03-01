using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class tempscenecontroller : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button cornerButton;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LoggedInMenu")
        {
            playButton.onClick.AddListener(() => { LoadNextScene("GameplayScene"); });
            quitButton.onClick.AddListener(() => { QuitApplication(); });
        }
        else if (SceneManager.GetActiveScene().name == "GameplayScene")
        {
            cornerButton.onClick.AddListener(() => { LoadNextScene("LoggedInMenu"); });
        }

    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
