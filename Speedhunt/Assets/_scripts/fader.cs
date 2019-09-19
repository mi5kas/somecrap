using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        RawImage temp = GetComponent<RawImage>();
        StartCoroutine("FadeSound");
        temp.CrossFadeAlpha(1, 0, false);
        temp.CrossFadeAlpha(0, 1, false);
    }
    IEnumerator FadeSound()
    {
        AudioListener.volume=0f;
        while(AudioListener.volume < 1)
        {
            AudioListener.volume+=0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    // Update is called once per frame
}
