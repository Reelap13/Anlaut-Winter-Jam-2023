using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Passage : MonoBehaviour
{
    [SerializeField] string text;
    [SerializeField] AudioClip audio;
    [SerializeField] GameObject author;

    public string Text
    {
        get
        {
            return text;
        }
    }

    public AudioClip Audio
    {
        get
        {
            return audio;
        }
    }

    public string Author
    {
        get
        {
            return author.name;
        }
    }
}