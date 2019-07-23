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
        temp.CrossFadeAlpha(1, 0, false);
        temp.CrossFadeAlpha(0, 1, false);
    }
    // Update is called once per frame
}
