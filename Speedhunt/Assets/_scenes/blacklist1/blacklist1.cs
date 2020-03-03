using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blacklist1 : MonoBehaviour
{
    [SerializeField] Transform scottyNeck;
    [SerializeField] Transform[] eyes;
    [SerializeField] Transform neckLookAt;
    [SerializeField] Transform eyesLookAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        scottyNeck.LookAt(neckLookAt);
        eyes[0].LookAt(eyesLookAt);
        eyes[1].LookAt(eyesLookAt);
    }
}
