using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;
using UnityEngine.Networking;

public class testux : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string text;
    void Start()
    {
        Debug.Log(UnityWebRequest.Post("https://texttospeech.googleapis.com/v1/text:synthesize", text));
    }
    // Update is called once per frame
}
