using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash : MonoBehaviour
{
    bool slowed=false;
    // Start is called before the first frame update
    void Start()
    {
        slowed=false;
        Time.timeScale=1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SlowDown()
    {
        if(slowed)
        {
            Time.timeScale=1f;
            slowed=false;
        }
        else
        {
            Time.timeScale=0.3f;
            slowed=true;
        }
    }
}
