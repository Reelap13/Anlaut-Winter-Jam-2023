using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MakeSound : StepOfAct
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip clip;
    public override void StartStep()
    {
        audio.clip = clip;
        audio.Play();
        FinishStep();
    }
}
