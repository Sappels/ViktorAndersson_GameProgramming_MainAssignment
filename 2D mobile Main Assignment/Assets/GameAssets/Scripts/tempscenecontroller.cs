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
    public Button leaderboardButton;
    public Button cornerButton;
    public Button backToMainButton;
    public Button settingsButton;

    private TMP_Text currentUserText;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LoggedInMenu")
        {
            playButton.onClick.AddListener(() => { LoadNextScene("GameplayScene"); });
            settingsButton.onClick.AddListener(() => { LoadNextScene("Settings"); });
            leaderboardButton.onClick.AddListener(() => { LoadNextScene("LeaderBoard"); });
            quitButton.onClick.AddListener(() => { QuitApplication(); });
        }
        else if (SceneManager.GetActiveScene().name == "GameplayScene")
        {
            cornerButton.onClick.AddListener(() => { LoadNextScene("LoggedInMenu"); });
        }
        else if (SceneManager.GetActiveScene().name == "Leaderboard" || SceneManager.GetActiveScene().name == "Settings")
        {
            backToMainButton.onClick.AddListener(() => { LoadNextScene("LoggedInMenu"); });
        }

        if (SceneManager.GetActiveScene().name != "GameplayScene")
        {
            currentUserText = GameObject.Find("CurrentUser").GetComponent<TextMeshPro>();
            //currentUserText.text = SaveManager.Instance.LoadFromFirebase()
        }
        if (SceneManager.GetActiveScene().name == "Settings")
        {
            SoundManager.Instance.volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        }
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Settings")
        {
            SoundManager.Instance.audioSrc.volume = SoundManager.Instance.volumeSlider.value;
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
