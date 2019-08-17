using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float time = 3f;
    [SerializeField] Animator mia;
    void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        Invoke("ShowDialogue", time);
    }
    void ShowDialogue()
    {
        mia.CrossFadeInFixedTime("sitting2", 2f, 0);
        this.GetComponent<dialogs>().enabled=false;
        this.GetComponent<dialogs>().enabled=true;
    }
    // Update is called once per frame
}
