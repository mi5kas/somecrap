using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeMovement : MonoBehaviour
{
    bool look = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if(look)
            transform.LookAt(Camera.main.transform.position);
    }
    // Update is called once per frame
    public void LookAtCamera()
    {
        look=true;
    }
    public void ResetEyes()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        look=false;
    }
}
