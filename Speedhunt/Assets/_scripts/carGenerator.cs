using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carGenerator : MonoBehaviour
{
    [SerializeField] bool playerCar = true;
    //[SerializeField] Material carMaterial;
    [SerializeField] Vector2 enemyCar;
    public float enemyPower;
    // Start is called before the first frame update
    void Start()
    {
        int tempCarID;
        Transform[] suspension = new Transform[4];
        for(int i=0; i<4; i++)
        {
            suspension[i] = this.transform.GetChild(4+i);
        }
        if(playerCar)
        {
            tempCarID = PlayerPrefs.GetInt("currentCar");
            foreach(Material mat in this.transform.GetChild(0).GetChild(tempCarID).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Status", 0)).GetComponent<Renderer>().materials)
            {
                if(mat.name == "carMaterial (Instance)")
                {
                    mat.color = new Color(PlayerPrefs.GetFloat("car" + tempCarID + "Color1", 0), PlayerPrefs.GetFloat("car" + tempCarID + "Color2", 0), PlayerPrefs.GetFloat("car" + tempCarID + "Color2", 0), 1);
                    if(PlayerPrefs.GetInt("car" + tempCarID + "Status", 0) != 0)
                    {
                        mat.SetTexture("_MainTex", null);
                    }
                    break;
                }
            }
            foreach(Material mat in this.transform.GetChild(0).GetChild(tempCarID).GetComponent<Renderer>().materials)
            {
                if(mat.name == "carMaterial (Instance)")
                {
                    mat.color = new Color(PlayerPrefs.GetFloat("car" + tempCarID + "Color1", 0), PlayerPrefs.GetFloat("car" + tempCarID + "Color2", 0), PlayerPrefs.GetFloat("car" + tempCarID + "Color2", 0), 1);
                    if(PlayerPrefs.GetInt("car" + tempCarID + "Status", 0) != 0)
                    {
                        mat.SetTexture("_MainTex", null);
                    }
                    break;
                }
            }
            this.transform.GetChild(0).GetChild(tempCarID).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Status", 0)).gameObject.SetActive(true);
            for(int i=0; i<4; i++)
            {
                Renderer wheelMat = suspension[0].GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Wheels", 0)).GetComponent<Renderer>();
                wheelMat.gameObject.SetActive(true);
                if(PlayerPrefs.GetInt("car" + tempCarID + "Wheels", 0) != 0)
                {
                    foreach(Material mat in wheelMat.materials)
                    {
                        if(mat.name == "wheelMaterial")
                        {
                            mat.color = new Color(PlayerPrefs.GetFloat("car" + tempCarID + "WheelColor1"), PlayerPrefs.GetFloat("car" + tempCarID + "WheelColor2"), PlayerPrefs.GetFloat("car" + tempCarID + "WheelColor3"), 1);
                        }
                    }
                }
            }
        }
        else
        {
            tempCarID = Random.Range(Mathf.RoundToInt(enemyCar.x), Mathf.RoundToInt(enemyCar.y));
            int tempCarBodyKit = Random.Range(0, 2);
            this.transform.GetChild(0).GetChild(tempCarID).GetChild(tempCarBodyKit).gameObject.SetActive(true);
            Color enemyColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            foreach(Material mat in this.transform.GetChild(0).GetChild(tempCarID).GetChild(tempCarBodyKit).GetComponent<Renderer>().materials)
            {
                if(mat.name == "carMaterial (Instance)")
                {
                    mat.color = enemyColor;
                    mat.SetTexture("_MainTex", null);
                    break;
                }
            }
            foreach(Material mat in this.transform.GetChild(0).GetChild(tempCarID).GetComponent<Renderer>().materials)
            {
                if(mat.name == "carMaterial (Instance)")
                {
                    mat.color = enemyColor;
                    mat.SetTexture("_MainTex", null);
                    break;
                }
            }
            int randomWheels = Random.Range(1, 9);
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
            if(!playerCar)
            {
                enemyPower = 0.3f;
            }
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
            if(!playerCar)
            {
                enemyPower = 0.3f;
            }
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
            if(!playerCar)
            {
                enemyPower = 0.3f;
            }
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
            if(!playerCar)
            {
                enemyPower = 0.35f;
            }
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
            if(!playerCar)
            {
                enemyPower = 0.45f;
            }
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
            if(!playerCar)
            {
                enemyPower = 0.55f;
            }
        }
    }
}
