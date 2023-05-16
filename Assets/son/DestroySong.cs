using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroySong : MonoBehaviour
{
  public Button boutonArret;

    void Start()
    {
        boutonArret.onClick.AddListener(ArreterToutAudio);
    }

    void ArreterToutAudio()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
