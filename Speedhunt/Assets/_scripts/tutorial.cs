using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.1f;
        Invoke("StopTutorial", 0.6f);
    }
    void StopTutorial()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
}
