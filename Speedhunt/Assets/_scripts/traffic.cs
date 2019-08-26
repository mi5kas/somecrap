using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traffic : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public bool push=false;
    Transform[] wheels = new Transform[2];
    void Start()
    {
        int randomas = Random.Range(0, 3);
        rb = GetComponent<Rigidbody>();
        transform.GetChild(randomas).gameObject.SetActive(true);
        transform.GetChild(randomas).GetChild(0).GetComponent<Renderer>().materials[0].SetColor("_BaseColor", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
        InvokeRepeating("PushIt", 0.1f, 0.1f);
        wheels[0] = transform.GetChild(randomas).transform.GetChild(1);
        wheels[1] = transform.GetChild(randomas).transform.GetChild(2);
    }
    void OnCollisionEnter(Collision collider)
    {
        push=false;
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "playerCar")
            push=true;
    }
    void PushIt()
    {
        if(push)
        {
            rb.velocity = rb.transform.forward * 30f;
            wheels[0].transform.Rotate(wheels[0].rotation.x+40f, 0, 0);
            wheels[1].transform.Rotate(wheels[1].rotation.x+40f, 0, 0);
        }
    }
}
