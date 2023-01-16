using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ParticipantsOfDialog : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MakeSound(AudioClip clip)
    {

        audioSource.clip = clip;
        Debug.Log(audioSource.clip.name);
        audioSource.Play();
    }

    public void StopMakingSound()
    {
        audioSource.Stop();
    }
}
