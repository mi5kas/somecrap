using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowdControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform car;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        foreach(Transform children in this.transform.parent)
        {
            children.LookAt(car);
            //children.rotation = Quaternion.Euler(0, children.rotation.y, 0);
        }
    }
    // Update is called once per frame
}
