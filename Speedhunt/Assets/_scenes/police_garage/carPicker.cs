using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carPicker : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject nextScene;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<cars.Length; i++)
        {
            Transform tempBodykit = cars[i].transform.GetChild(3+PlayerPrefs.GetInt("car" + i + "Status", 0));
            tempBodykit.gameObject.SetActive(true);
            foreach(Material tempMaterial in tempBodykit.GetComponent<Renderer>().materials)
            {
                if(tempMaterial.name == "body (Instance)")
                {
                    tempMaterial.color = new Color(PlayerPrefs.GetFloat("car" + i + "Color1", 1), PlayerPrefs.GetFloat("car" + i + "Color2", 1), PlayerPrefs.GetFloat("car" + i + "Color3", 1), 1);
                    if(PlayerPrefs.GetInt("car" + i + "Status", 0) != 0)
                    {
                        tempMaterial.SetTexture("_MainTex", null);
                    }
                }
            }
            foreach(Material tempMaterial in cars[i].transform.GetChild(5).GetComponent<Renderer>().materials)
            {
                if(tempMaterial.name == "body (Instance)")
                {
                    tempMaterial.color = new Color(PlayerPrefs.GetFloat("car" + i + "Color1", 1), PlayerPrefs.GetFloat("car" + i + "Color2", 1), PlayerPrefs.GetFloat("car" + i + "Color3", 1), 1);
                    if(PlayerPrefs.GetInt("car" + i + "Status", 0) != 0)
                    {
                        tempMaterial.SetTexture("_MainTex", null);
                    }
                }
            }
            cars[i].transform.GetChild(0).GetChild(0).localScale = new Vector3(cars[i].transform.GetChild(0).GetChild(0).localScale.x+0.4f*PlayerPrefs.GetInt("car" + i + "Power", 0), 1, 1);
            cars[i].transform.GetChild(0).GetChild(0).localScale = new Vector3(cars[i].transform.GetChild(0).GetChild(1).localScale.x+0.4f*PlayerPrefs.GetInt("car" + i + "Handling", 0), 1, 1);
        }
        if(PlayerPrefs.GetInt("sideStory1", 0) != 1)
        {
            cars[0].SetActive(false);
        }
        cars[PlayerPrefs.GetInt("currentCar", 0)].SetActive(false);
    }
    public void AcceptCar()
    {
        for(int i=0; i<cars.Length; i++)
        {
            if(cars[i].transform.GetChild(0).gameObject.activeSelf)
            {
                cars[i].transform.GetChild(1).gameObject.SetActive(true);
                PlayerPrefs.SetInt("currentCar", i);
                buttons.SetActive(false);
                Invoke("TurnOnCar", 1f);
                break;
            }
        }
    }
    void TurnOnCar()
    {
        for(int i=0; i<cars.Length; i++)
        {
            if(cars[i].transform.GetChild(0).gameObject.activeSelf)
            {
                foreach(Material tempMaterial in cars[i].transform.GetChild(5).GetComponent<Renderer>().materials)
                {
                    if(tempMaterial.name == "lights (Instance)")
                    {
                        tempMaterial.EnableKeyword("_EMISSION");
                        nextScene.SetActive(true);
                        break;
                    }
                }
            }
        }
    }
    public void RejectCar()
    {
        foreach(GameObject car in cars)
        {
            if(car.transform.GetChild(0).gameObject.activeSelf)
            {
                car.transform.GetChild(0).gameObject.SetActive(false);
                buttons.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                player.SetActive(true);
                break;
            }
        }
    }
    // Update is called once per frame
}
