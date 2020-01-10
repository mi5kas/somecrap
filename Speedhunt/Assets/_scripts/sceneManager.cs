using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    [SerializeField] int[] requirements;
    [SerializeField] GameObject[] cutscenes;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<requirements.Length; i++)
        {
            if(PlayerPrefs.GetInt("story", 0) == requirements[i])
            {
                cutscenes[i+1].SetActive(true);
                return;
            }
        }
        cutscenes[0].SetActive(true);
    }
}
