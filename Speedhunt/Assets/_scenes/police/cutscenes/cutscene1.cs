using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float time = 3f;
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
        this.GetComponent<dialogs>().enabled=false;
        this.GetComponent<dialogs>().enabled=true;
    }
    // Update is called once per frame
}
