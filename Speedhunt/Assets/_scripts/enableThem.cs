using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enableThem : MonoBehaviour
{
    [SerializeField] GameObject[] toEnable;
    [SerializeField] GameObject[] toDisable;
    [SerializeField] RawImage fader = null;
    // Start is called before the first frame update
    void Start()
    {
        //OnEnable();
    }
    void OnEnable()
    {
        if(fader == null)
        {
            EnableThem();
        }
        else
        {
            fader.CrossFadeAlpha(1f, 1f, false);
            Invoke("EnableThem", 1.5f);
        }
    }
    void EnableThem()
    {
            if(fader != null)
            {
                fader.CrossFadeAlpha(0, 1f, false);
            }
            foreach(GameObject obj in toDisable)
            {
                obj.SetActive(false);
            }
            foreach(GameObject obj in toEnable)
            {
                obj.SetActive(true);
            }
    }
    // Update is called once per frame
}
