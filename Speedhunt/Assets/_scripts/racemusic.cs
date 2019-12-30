using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racemusic : MonoBehaviour
{

    [SerializeField] AudioClip[] music;
    [SerializeField] AudioClip[] musicEnds;
    int whichMusic;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        whichMusic = Random.Range(0, music.Length);
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = music[whichMusic];
        audioSource.Play();
    }
    public void PlayEnding()
    {
        audioSource.clip = musicEnds[whichMusic];
        audioSource.Play();
    }
    // Update is called once per frame
}
