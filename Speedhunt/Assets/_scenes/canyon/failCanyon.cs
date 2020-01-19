using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failCanyon : MonoBehaviour
{
    [SerializeField] GameObject failer;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        failer.SetActive(true);
    }
}
