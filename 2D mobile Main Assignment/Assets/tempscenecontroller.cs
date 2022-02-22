using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class tempscenecontroller : MonoBehaviour
{
    public Button playButton;


    void Start()
    {
        playButton.onClick.AddListener(() => { LoadNextScene(); });

        playButton.interactable = false;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
