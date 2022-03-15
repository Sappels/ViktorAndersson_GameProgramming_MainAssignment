using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource audioSrc;
    public Slider volumeSlider;

    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform);

        audioSrc = GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (audioSrc.isPlaying) return;
        audioSrc.volume = volumeSlider.value;
        audioSrc.Play();
    }
}
