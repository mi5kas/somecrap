﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tuningSystem : MonoBehaviour
{
    [SerializeField] Transform playerCar;
    [SerializeField] Text confirmMod;
    [SerializeField] ColorPicker colorPalette;
    [SerializeField] GameObject[] tuningCameras;
    [SerializeField] Text moneyText;
    [SerializeField] Material playerMaterial;
    [SerializeField] Button[] tuningButtons;
    [SerializeField] Text[] levelTexts;
    [SerializeField] Text[] costTexts;
    [SerializeField] GameObject wheelButtons;
    [SerializeField] Material wheelsMaterial;
    [SerializeField] RectTransform powerLine;
    [SerializeField] RectTransform handlingLine;
    [SerializeField] Transform[] suspensions;
    [SerializeField] AudioSource repairSound;
    Color defaultColor;
    int currentWheels;
    int whichModConfirmed;
    // Start is called before the first frame update
    void Start()
    {
        UpdateButtons();
        defaultColor = playerMaterial.GetColor("_Color");
    }
    public void Tuning(int whichMod)
    {
        whichModConfirmed = whichMod;
        tuningButtons[0].transform.parent.gameObject.SetActive(false);
        if(whichMod == 0)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "<#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine") + " <#ffffffff>engine upgrade will increase your power by <#2eacd5ff>" + (10+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")) + "%<#ffffffff>. This upgrade costs <#2eacd5ff>" + 300*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")+1) + "$<#ffffffff>. Do you wish to proceed?";
        }
        else if(whichMod == 1)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "<#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension") + " <#ffffffff>suspension upgrade will increase your handling by <#2eacd5ff>" + (10+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")) + "%<#ffffffff>. This upgrade costs <#2eacd5ff>" + 200*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")+1) + "$<#ffffffff>. Do you wish to proceed?";
        }
        else if(whichMod == 2)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "<#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous") + " <#ffffffff>nitrous upgrade will increase your nitrous boost by <#2eacd5ff>" + (1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")) + "s<#ffffffff>. This upgrade costs <#2eacd5ff>" + 400*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")+1) + "$<#ffffffff>. Do you wish to proceed?";
        }
        else if(whichMod == 3)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "This will remove all rust and body damage. It costs <#2eacd5ff>400$<#ffffffff>. Do you wish to proceed?";
        }
        else if(whichMod == 4)
        {
            colorPalette.gameObject.SetActive(true);
            colorPalette.CurrentColor = playerMaterial.GetColor("_Color");
            tuningCameras[0].SetActive(true);
            tuningButtons[0].transform.parent.gameObject.SetActive(false);
        }
        else if(whichMod == 5)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "This will apply body kit on your car. No performance boosts but it will look cool. This modification costs <#2eacd5ff>1000$<#ffffffff>. Do you wish to proceed?";
            playerCar.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(2).gameObject.SetActive(true);
            playerCar.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status")).gameObject.SetActive(false);
        }
        else if(whichMod == 6)
        {
            tuningCameras[1].SetActive(true);
            wheelButtons.SetActive(true);
            currentWheels = PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Wheels");
        }
        else if(whichMod == 7)
        {
            tuningCameras[1].SetActive(true);
            colorPalette.gameObject.SetActive(true);
            colorPalette.CurrentColor = wheelsMaterial.GetColor("_Color");
        }
    }
    public void ShiftWheels(int direction)
    {
        if(direction == 0)
        {
            int nextWheel = currentWheels+1;
            if(nextWheel > 9)
            {
                nextWheel = 1;
            }
            foreach(Transform child in suspensions)
            {
                child.GetChild(0).GetChild(0).GetChild(currentWheels).gameObject.SetActive(false);
                child.GetChild(0).GetChild(0).GetChild(nextWheel).gameObject.SetActive(true);
            }
            currentWheels=nextWheel;
        }
        else
        {
            int nextWheel = currentWheels-1;
            if(nextWheel < 1)
            {
                nextWheel = 9;
            }
            foreach(Transform child in suspensions)
            {
                child.GetChild(0).GetChild(0).GetChild(currentWheels).gameObject.SetActive(false);
                child.GetChild(0).GetChild(0).GetChild(nextWheel).gameObject.SetActive(true);
            }
            currentWheels=nextWheel;
        }
    }
    public void ShowColor()
    {
        if(tuningCameras[0].activeSelf)
            playerMaterial.SetColor("_Color", colorPalette.CurrentColor);
        else
            wheelsMaterial.SetColor("_Color", colorPalette.CurrentColor);
    }
    public void RejectTuning()
    {
        if(whichModConfirmed < 4)
        {
            confirmMod.gameObject.SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
        }
        else if(whichModConfirmed == 4)
        {
            colorPalette.gameObject.SetActive(false);
            playerMaterial.SetColor("_Color", defaultColor);
            tuningCameras[0].SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
        }
        else if(whichModConfirmed == 5)
        {
            confirmMod.gameObject.SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
            playerCar.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(2).gameObject.SetActive(false);
            playerCar.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status")).gameObject.SetActive(true);
        }
        else if(whichModConfirmed == 6)
        {
            foreach(Transform child in suspensions)
            {
                child.GetChild(0).GetChild(0).GetChild(currentWheels).gameObject.SetActive(false);
                child.GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Wheels")).gameObject.SetActive(true);
            }
            wheelButtons.SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
            tuningCameras[1].SetActive(false);
        }
        else if(whichModConfirmed == 7)
        {
            wheelsMaterial.SetColor("_Color", new Color(PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor1"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor2"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor3"), 1));
            tuningCameras[1].SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
            colorPalette.gameObject.SetActive(false);
        }
    }
    void UpdateButtons()
    {
        int currentMoney = PlayerPrefs.GetInt("money");
        if(currentMoney < 300*(1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")))
        {
            tuningButtons[0].interactable = false;
            levelTexts[0].transform.parent.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            levelTexts[0].color =  new Color(1, 1, 1, 0.5f);
            costTexts[0].color =  new Color(1, 1, 1, 0.5f);
        }
        if(currentMoney < 200*(1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")))
        {
            tuningButtons[1].interactable = false;
            levelTexts[1].transform.parent.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            levelTexts[1].color =  new Color(1, 1, 1, 0.5f);
            costTexts[1].color =  new Color(1, 1, 1, 0.5f);
        }
        if(currentMoney < 400*(1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")))
        {
            tuningButtons[2].interactable = false;
            levelTexts[2].transform.parent.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            levelTexts[2].color =  new Color(1, 1, 1, 0.5f);
            costTexts[2].color =  new Color(1, 1, 1, 0.5f);
        }
        if(currentMoney < 500 || PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status") != 0)
        {
            tuningButtons[3].interactable = false;
            tuningButtons[3].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        if(currentMoney < 1000 || PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status") == 0)
        {
            tuningButtons[4].interactable = false;
            tuningButtons[4].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        if(currentMoney < 1000 || PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status") == 2)
        {
            tuningButtons[5].interactable = false;
            tuningButtons[5].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        if(currentMoney < 400)
        {
            tuningButtons[6].interactable = false;
            tuningButtons[6].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        if(currentMoney < 200 || PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Wheels") == 0)
        {
            tuningButtons[7].interactable = false;
            tuningButtons[7].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        powerLine.localScale = new Vector3(PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Power"), 1, 1);
        handlingLine.localScale = new Vector3(PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Handling"), 1, 1);
        moneyText.text = "MONEY: " + currentMoney + "$";
        levelTexts[0].text = "LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine");
        costTexts[0].text = 400*(1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")) + "$";
        levelTexts[1].text = "LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension");
        costTexts[1].text = 200*(1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")) + "$";
        levelTexts[2].text = "LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous");
        costTexts[1].text = 400*(1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")) + "$";
    }
    public void BuyTuning()
    {
        if(whichModConfirmed == 0)
        {
            confirmMod.transform.parent.gameObject.SetActive(false);
            PlayerPrefs.SetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine", PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")+1);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-400*PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine"));
            PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Power", PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Power")+0.1f+PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Power")/100f);
        }
        else if(whichModConfirmed == 1)
        {
            confirmMod.transform.parent.gameObject.SetActive(false);
            PlayerPrefs.SetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension", PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")+1);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-200*PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension"));
            PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Handling", PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Handling")+0.1f+PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Handling")/100f);
        }
        else if(whichModConfirmed == 2)
        {
            confirmMod.transform.parent.gameObject.SetActive(false);
            PlayerPrefs.SetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous", PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")+1);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-400*PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous"));

        }
        else if(whichModConfirmed == 3)
        {
            confirmMod.transform.parent.gameObject.SetActive(false);
            PlayerPrefs.SetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status", 1);
            playerCar.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(0).gameObject.SetActive(false);
            playerCar.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(1).gameObject.SetActive(true);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-500);
        }
        else if(whichModConfirmed == 4)
        {
            colorPalette.gameObject.SetActive(false);
            defaultColor = colorPalette.CurrentColor;
            tuningCameras[0].SetActive(false);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-1000);
        }
        else if(whichModConfirmed == 5)
        {
            tuningCameras[0].SetActive(false);
            confirmMod.transform.parent.gameObject.SetActive(false);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-1000);
            PlayerPrefs.SetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status", 2);
        }
        else if(whichModConfirmed == 6)
        {
            tuningCameras[1].SetActive(false);
            wheelButtons.SetActive(false);
            if(currentWheels != PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Wheels"))
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-400);
                PlayerPrefs.SetInt("car" + PlayerPrefs.GetInt("currentCar") + "Wheels", currentWheels);
            }
        }
        else if(whichModConfirmed == 7)
        {
            tuningCameras[1].SetActive(false);
            colorPalette.gameObject.SetActive(false);
            if(colorPalette.CurrentColor != new Color(PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor1"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor2"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor3"), 1))
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-200);
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor1", colorPalette.CurrentColor.r);
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor2", colorPalette.CurrentColor.g);
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor3", colorPalette.CurrentColor.b);
            }
        }
        UpdateButtons();
        repairSound.Play();
        tuningButtons[0].transform.parent.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
