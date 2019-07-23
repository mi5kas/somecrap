using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walkObjective : MonoBehaviour
{
    [SerializeField] GameObject toActivate;
    [SerializeField] RawImage fader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        fader.CrossFadeAlpha(1, 1f, false);
        Invoke("ActivateObject", 1.5f);
    }
    void ActivateObject()
    {
        fader.CrossFadeAlpha(0, 1f, false);
        toActivate.SetActive(false);
        toActivate.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
