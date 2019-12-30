using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carGenerator : MonoBehaviour
{
    [SerializeField] bool playerCar = true;
    [SerializeField] int debugCar = 0;
    [SerializeField] Material carMaterial;
    [SerializeField] Texture dirtTexture;
    // Start is called before the first frame update
    void Start()
    {
        int tempCarID;
        Transform[] suspension = new Transform[4];
        PlayerPrefs.SetInt("currentCar", debugCar);
        for(int i=0; i<4; i++)
        {
            suspension[i] = this.transform.GetChild(4+i);
        }
        if(playerCar)
        {
            tempCarID = PlayerPrefs.GetInt("currentCar");
            this.transform.GetChild(0).GetChild(tempCarID).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Status", 0)).gameObject.SetActive(true);
            carMaterial.color = new Color(PlayerPrefs.GetFloat("car" + tempCarID + "Color1", 0), PlayerPrefs.GetFloat("car" + tempCarID + "Color2", 0), PlayerPrefs.GetFloat("car" + tempCarID + "Color2", 0), 1);
            if(PlayerPrefs.GetInt("car" + tempCarID + "Status", 0) == 0)
            {
                carMaterial.SetTexture("_BaseMap", dirtTexture);
            }
            suspension[0].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Wheels", 0)).gameObject.SetActive(true);
            suspension[1].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Wheels", 0)).gameObject.SetActive(true);
            suspension[2].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Wheels", 0)).gameObject.SetActive(true);
            suspension[3].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Wheels", 0)).gameObject.SetActive(true);
        }
        else
        {
            tempCarID = Random.Range(0, 3);
            int randomWheels = Random.Range(1, 9);
            carMaterial.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            this.transform.GetChild(0).GetChild(tempCarID).GetChild(Random.Range(0, 2)).gameObject.SetActive(true);
            suspension[0].GetChild(0).GetChild(0).GetChild(randomWheels).gameObject.SetActive(true);
            suspension[1].GetChild(0).GetChild(0).GetChild(randomWheels).gameObject.SetActive(true);
            suspension[2].GetChild(0).GetChild(0).GetChild(randomWheels).gameObject.SetActive(true);
            suspension[3].GetChild(0).GetChild(0).GetChild(randomWheels).gameObject.SetActive(true);
        }
        this.transform.GetChild(0).GetChild(tempCarID).gameObject.SetActive(true);
        if(tempCarID == 0) //Civic
        {
            suspension[0].localPosition = new Vector3(-0.84f, -0.20f, 1.335f);
            suspension[1].localPosition = new Vector3(0.84f, -0.20f, -1.475f);
            suspension[2].localPosition = new Vector3(0.84f, -0.2f, 1.335f);
            suspension[3].localPosition = new Vector3(-0.84f, -0.2f, -1.475f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        else if(tempCarID == 1) //E36
        {
            suspension[0].localPosition = new Vector3(-0.9f, -0.20f, 1.73f);
            suspension[1].localPosition = new Vector3(0.9f, -0.20f, -1.54f);
            suspension[2].localPosition = new Vector3(0.9f, -0.2f, 1.73f);
            suspension[3].localPosition = new Vector3(-0.9f, -0.2f, -1.54f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
        }
        else if(tempCarID == 2) //Golf
        {
            suspension[0].localPosition = new Vector3(-0.87f, -0.20f, 1.29f);
            suspension[1].localPosition = new Vector3(0.87f, -0.20f, -1.5f);
            suspension[2].localPosition = new Vector3(0.87f, -0.2f, 1.29f);
            suspension[3].localPosition = new Vector3(-0.87f, -0.2f, -1.5f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        else if(tempCarID == 3) //Miata
        {
            suspension[0].localPosition = new Vector3(-0.81f, -0.20f, 1.27f);
            suspension[1].localPosition = new Vector3(0.81f, -0.20f, -1.21f);
            suspension[2].localPosition = new Vector3(0.81f, -0.2f, 1.27f);
            suspension[3].localPosition = new Vector3(-0.81f, -0.2f, -1.21f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        else if(tempCarID == 4) //RX8
        {  
            suspension[0].localPosition = new Vector3(-0.93f, -0.20f, 1.63f);
            suspension[1].localPosition = new Vector3(0.93f, -0.20f, -1.475f);
            suspension[2].localPosition = new Vector3(0.93f, -0.2f, 1.63f);
            suspension[3].localPosition = new Vector3(-0.93f, -0.2f, -1.475f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
        }
        else if(tempCarID == 5) //Skyline
        {
            suspension[0].position = new Vector3(-0.85f, -0.20f, 1.42f);
            suspension[1].position = new Vector3(0.85f, -0.20f, -1.48f);
            suspension[2].position = new Vector3(0.85f, -0.2f, 1.42f);
            suspension[3].position = new Vector3(-0.85f, -0.2f, -1.48f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
