using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip menuClip;
    public AudioClip levelClip;

    private AudioClip currentClip;
    AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        { 
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        currentClip = menuClip;
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }



    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex > 3)
        {
            PlaySoundTrack(levelClip);
            currentClip = levelClip;
        }
        else
        {
            PlaySoundTrack(menuClip);
            currentClip = menuClip;
        }
    }

    void PlaySoundTrack(AudioClip soundtrack)
    {
        if(soundtrack != currentClip)
        {
            instance.audioSource.clip = soundtrack;
            audioSource.Play();
        }
    }


    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
