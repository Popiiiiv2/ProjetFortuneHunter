using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volumeSlider; // Référence vers le Slider dans l'interface utilisateur
    public AudioSource audioSource; // Référence vers le composant AudioSource

    private void Start()
    {
        // S'assurer que le volume initial est réglé correctement
        if (audioSource != null)
        {
            volumeSlider.value = audioSource.volume;
        }
    }

    public void SetVolume(float volume)
    {
        // Mettre à jour le volume de l'AudioSource avec la valeur du Slider
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
