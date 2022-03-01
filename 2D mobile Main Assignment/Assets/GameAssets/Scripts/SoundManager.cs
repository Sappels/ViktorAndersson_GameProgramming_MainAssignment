using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private AudioSource audioSrc;

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
        audioSrc.Play();
    }

}
