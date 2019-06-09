using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carGenerator : MonoBehaviour
{
    [SerializeField] bool playerCar = true;
    [SerializeField] Transform carObject;
    [SerializeField] Transform[] suspension;
    [SerializeField] Material carColor;
    // Start is called before the first frame update
    void Start()
    {
        int tempCarID;
        if(playerCar)
        {
            tempCarID = PlayerPrefs.GetInt("carID");
            carObject.GetChild(tempCarID).GetChild(PlayerPrefs.GetInt("carBody")).gameObject.SetActive(true);
            suspension[0].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("carWheels")).gameObject.SetActive(true);
            suspension[1].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("carWheels")).gameObject.SetActive(true);
            suspension[2].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("carWheels")).gameObject.SetActive(true);
            suspension[3].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("carWheels")).gameObject.SetActive(true);
        }
        else
        {
            tempCarID = Random.Range(0, 3);
            int randomWheels = Random.Range(1, 9);
            suspension[0].GetChild(0).GetChild(0).GetChild(randomWheels).gameObject.SetActive(true);
            suspension[1].GetChild(0).GetChild(0).GetChild(randomWheels).gameObject.SetActive(true);
            suspension[2].GetChild(0).GetChild(0).GetChild(randomWheels).gameObject.SetActive(true);
            suspension[3].GetChild(0).GetChild(0).GetChild(randomWheels).gameObject.SetActive(true);
        }
        carObject.GetChild(tempCarID).gameObject.SetActive(true);
        if(tempCarID == 0) //Civic
        {
            suspension[0].position = new Vector3(-0.85f, -0.20f, 1.323f);
            suspension[1].position = new Vector3(0.85f, -0.20f, -1.48f);
            suspension[2].position = new Vector3(0.85f, -0.2f, 1.323f);
            suspension[3].position = new Vector3(-0.85f, -0.2f, -1.48f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        else if(tempCarID == 1) //E36
        {
            suspension[0].position = new Vector3(-0.89f, -0.20f, 1.714f);
            suspension[1].position = new Vector3(0.89f, -0.20f, -1.505f);
            suspension[2].position = new Vector3(0.89f, -0.2f, 1.714f);
            suspension[3].position = new Vector3(-0.89f, -0.2f, -1.505f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(1f, 1f, 1f);
        }
        else if(tempCarID == 2) //Golf
        {
            suspension[0].position = new Vector3(-0.86f, -0.20f, 1.284f);
            suspension[1].position = new Vector3(0.835f, -0.20f, -1.486f);
            suspension[2].position = new Vector3(0.835f, -0.2f, 1.284f);
            suspension[3].position = new Vector3(-0.86f, -0.2f, -1.486f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        else if(tempCarID == 3) //Miata
        {
            suspension[0].position = new Vector3(-0.82f, -0.20f, 1.28f);
            suspension[1].position = new Vector3(0.82f, -0.20f, -1.24f);
            suspension[2].position = new Vector3(0.82f, -0.2f, -1.24f);
            suspension[3].position = new Vector3(-0.82f, -0.2f, -1.486f);
            suspension[0].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[1].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[2].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
            suspension[3].GetChild(0).GetChild(0).localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        else if(tempCarID == 4) //Skyline
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
