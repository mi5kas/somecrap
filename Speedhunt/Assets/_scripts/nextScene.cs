using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    [SerializeField] RawImage fader;
    [SerializeField] int sceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        if(fader)
        {
            fader.CrossFadeAlpha(1, 2f, false);
            Invoke("LoadScene", 2f);
            StartCoroutine("FadeSound");
        }
        else
            LoadScene();
    }
    IEnumerator FadeSound()
    {
        AudioListener.volume=1f;
        while(AudioListener.volume > 0)
        {
            AudioListener.volume-=0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    // Update is called once per frame
}
