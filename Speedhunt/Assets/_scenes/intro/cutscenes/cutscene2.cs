using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene2 : MonoBehaviour
{
    [SerializeField] GameObject nextCutscene;
    [SerializeField] Animator cars;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "playerCar")
        {
            nextCutscene.SetActive(true);
            cars.enabled = true;
            cars.Play("cutscene5");
        }
    }
}
