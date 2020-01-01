using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garageCutscene1 : MonoBehaviour
{
    int cutsceneVar = 0;
    [SerializeField] Animator jeff;
    [SerializeField] Animator michelle;
    [SerializeField] Animator playerCar;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        cutsceneVar++;
        if(cutsceneVar == 1)
        {
            jeff.Play("cutscene1");
            michelle.Play("Working On Device");
            michelle.transform.position = new Vector3(6.29f, -0.736f, -3.83f);
            michelle.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(cutsceneVar == 2)
        {
            jeff.Play("cutscene2");
        }
        else if(cutsceneVar == 3)
        {
            michelle.Play("cutscene3");
            michelle.transform.position = new Vector3 (3.55f, -0.736f, -5.28f);
            michelle.transform.rotation = Quaternion.Euler(0, -160.4f, 0);
        }
        else if(cutsceneVar == 4)
        {
            PlayerPrefs.SetInt("car" + PlayerPrefs.GetInt("currentCar", 0) + "Status", 1);
            playerCar.transform.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(0).gameObject.SetActive(false);
            playerCar.transform.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(1).gameObject.SetActive(true);
            michelle.Play("cutscene3");
            playerCar.Play("playerCar_garage1");
            michelle.transform.position = new Vector3(3.39f, -0.736f, -9.602f);
            michelle.transform.rotation = Quaternion.Euler(0, 90f, 0);
        }
    }
    // Update is called once per frame
}
