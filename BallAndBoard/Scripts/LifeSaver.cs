using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSaver : MonoBehaviour
{
    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!myAudioSource.isPlaying)
            {
                myAudioSource.Play();
            }
            Destroy(gameObject, 0.6f);

        }
    }
}
