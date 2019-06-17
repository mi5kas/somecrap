using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testux : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pushcar = false;
    public float thrust;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pushcar)
        {
            pushcar=false;
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * thrust);
        }
    }
}
