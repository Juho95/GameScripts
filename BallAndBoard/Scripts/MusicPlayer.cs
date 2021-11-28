using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] audios;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audios[0];
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
        audioSource.Play();
    }

    private void Update()
    {
        ChangeAudio();
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void ChangeAudio()
    {
        if (SceneManager.GetSceneByName("Title Scene").isLoaded && audioSource.clip != audios[0])
        {
            audioSource.clip = audios[0];
            audioSource.loop = true;
            audioSource.Play();
            Debug.Log("Playing audio called: " + audios[0]);
        }
        else if(SceneManager.GetSceneByName("End Scene").isLoaded  && audioSource.clip != audios[1])
        {
            audioSource.clip = audios[1];
            audioSource.loop = true;
            audioSource.Play();
            Debug.Log("Playing audio called: " + audios[1]);
        }
    }
}
