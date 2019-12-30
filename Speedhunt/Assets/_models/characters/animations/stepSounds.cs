using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepSounds : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Step()
    {
        audio.Play();
    }
}
