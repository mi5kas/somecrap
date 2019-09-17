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
        }
        else
            LoadScene();
    }
    void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    // Update is called once per frame
}
