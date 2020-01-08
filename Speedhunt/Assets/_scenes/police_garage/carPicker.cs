using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carPicker : MonoBehaviour
{
    [SerializeField] Transform cars;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject nextScene;
    [SerializeField] GameObject player;
    [SerializeField] GameObject introCutscene;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("story", 0) == 1)
        {
            introCutscene.SetActive(true);
        }
        else
        {
            player.SetActive(true);
        }
        for(int i=0; i<cars.childCount; i++)
        {
            if(PlayerPrefs.GetInt("car" + i + "Power") > 0)
            {
                cars.GetChild(i).gameObject.SetActive(true);
                Transform tempBodykit = cars.GetChild(i).transform.GetChild(2+PlayerPrefs.GetInt("car" + i + "Status", 0));
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
                foreach(Material tempMaterial in cars.GetChild(i).transform.GetChild(5).GetComponent<Renderer>().materials)
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
                for(int w=0; w<4; w++)
                {
                    Renderer tempWheel = cars.GetChild(i).transform.GetChild(6+w).GetChild(PlayerPrefs.GetInt("car" + i + "Wheels", 0)).GetComponent<Renderer>();
                    tempWheel.gameObject.SetActive(true);
                    if(PlayerPrefs.GetInt("car" + i + "Wheels", 0) != 0)
                        tempWheel.materials[0].SetColor("_Color", new Color(PlayerPrefs.GetFloat("car" + i + "WheelColor1", 0.5f), PlayerPrefs.GetFloat("car" + i + "WheelColor2", 0.5f), PlayerPrefs.GetFloat("car" + i + "WheelColor3", 0.5f), 1));
                }
                cars.GetChild(i).transform.GetChild(0).GetChild(0).localScale = new Vector3(5*PlayerPrefs.GetInt("car" + i + "Power", 0), 0.5f, 1);
                cars.GetChild(i).transform.GetChild(0).GetChild(1).localScale = new Vector3(5*PlayerPrefs.GetInt("car" + i + "Handling", 0), 0.5f, 1);
            }
        }
    }
    public void AcceptCar()
    {
        for(int i=0; i<cars.childCount; i++)
        {
            if(cars.GetChild(i).transform.GetChild(0).gameObject.activeSelf)
            {
                cars.GetChild(i).transform.GetChild(1).gameObject.SetActive(true);
                PlayerPrefs.SetInt("currentCar", i);
                buttons.SetActive(false);
                Invoke("TurnOnCar", 1f);
                break;
            }
        }
    }
    void TurnOnCar()
    {
        for(int i=0; i<cars.childCount; i++)
        {
            if(cars.GetChild(i).transform.GetChild(0).gameObject.activeSelf)
            {
                foreach(Material tempMaterial in cars.GetChild(i).transform.GetChild(5).GetComponent<Renderer>().materials)
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
                Cursor.visible = false;
                player.SetActive(true);
                break;
            }
        }
    }
    // Update is called once per frame
}
