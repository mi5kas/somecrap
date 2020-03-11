using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leahShower : MonoBehaviour
{
    [SerializeField] Animator leah;
    [SerializeField] Transform head;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("leahStory", 0) == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            leah.CrossFadeInFixedTime("covering", 0.5f, 0);
            //StartCoroutine("RotateTowardsCamera");
            leah.transform.LookAt(Camera.main.transform);
            leah.transform.eulerAngles = new Vector3(0, leah.transform.rotation.y, 0);
            PlayerPrefs.SetInt("leahStory", 1);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            leah.CrossFadeInFixedTime("covering2", 0.5f, 0);
            //StartCoroutine("RotateTowardsCamera");
            leah.transform.LookAt(Camera.main.transform);
            leah.transform.eulerAngles = new Vector3(0, leah.transform.rotation.y, 0);
            PlayerPrefs.SetInt("leahStory", 2);
        }
    }
    void LateUpdate()
    {
        head.LookAt(Camera.main.transform);
    }
    // Update is called once per frame
}
