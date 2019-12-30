using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RVP;
using UnityEngine.UI;

public class driftSystem : MonoBehaviour
{
    //[SerializeField] Transform playerCar;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().enabled=false;
        this.GetComponent<BasicInput>().enabled=true;
        this.GetComponent<StuntDetect>().enabled=true;
        this.GetComponent<speedometer>().enabled=true;
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * 5f;
;    }

    // Update is called once per frame
}
