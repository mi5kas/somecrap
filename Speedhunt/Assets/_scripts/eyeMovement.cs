using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LookAtCamera()
    {
        this.transform.LookAt(Camera.main.transform);
    }
    public void ResetEyes()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
