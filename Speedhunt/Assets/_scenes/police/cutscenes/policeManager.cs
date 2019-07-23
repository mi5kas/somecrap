using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeManager : MonoBehaviour
{
    [SerializeField] GameObject[] things;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("story", 0) == 0)
        {
            things[1].SetActive(true);
        }
        else
        {
            things[0].SetActive(true);
        }
    }

    // Update is called once per frame
}
