using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepSounds : MonoBehaviour
{
    AudioSource stepSound;
    // Start is called before the first frame update
    void Start()
    {
        stepSound = GetComponent<AudioSource>();
    }
    public void Step()
    {
        stepSound.Play();
        Debug.Log("Sounds");
    }
}
