using System.Collections;
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
    Color defaultColor;
    int whichModConfirmed;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "MONEY: " + PlayerPrefs.GetInt("money") + "$";
        defaultColor = playerMaterial.GetColor("_Color");
    }
    public void Tuning(int whichMod)
    {
        confirmMod.transform.parent.gameObject.SetActive(true);
        whichModConfirmed = whichMod;
        if(whichMod == 0)
        {
            confirmMod.text = "<#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine") + " <#ffffffff>engine upgrade will increase your power by <#2eacd5ff>" + (10+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")) + "%<#ffffffff>. This upgrade costs <#2eacd5ff>" + 300*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")+1) + "$<#ffffffff>. Do you wish to proceed?";
        }
        else if(whichMod == 1)
        {
            confirmMod.text = "<#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension") + " <#ffffffff>suspension upgrade will increase your handling by <#2eacd5ff>" + (10+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")) + "%<#ffffffff>. This upgrade costs <#2eacd5ff>" + 200*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")+1) + "$<#ffffffff>. Do you wish to proceed?";
        }
        else if(whichMod == 2)
        {
            confirmMod.text = "<#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous") + " <#ffffffff>nitrous upgrade will increase your nitrous boost by <#2eacd5ff>" + (1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")) + "s<#ffffffff>. This upgrade costs <#2eacd5ff>" + 400*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")+1) + "$<#ffffffff>. Do you wish to proceed?";
        }
        else if(whichMod == 3)
        {
            confirmMod.text = "This will remove all rust and body damage. It costs <#2eacd5ff>400$<#ffffffff>. Do you wish to proceed?";
        }
        else if(whichMod == 4)
        {
            colorPalette.gameObject.SetActive(true);
            colorPalette.CurrentColor = playerMaterial.GetColor("_Color");
            tuningCameras[0].SetActive(true);
            tuningButtons[0].transform.parent.gameObject.SetActive(false);
        } 
    }
    public void ShowColor()
    {
        playerMaterial.SetColor("_Color", colorPalette.CurrentColor);
    }
    public void RejectTuning()
    {
        if(whichModConfirmed < 3)
        {
            confirmMod.gameObject.SetActive(false);
        }
        else if(whichModConfirmed == 4)
        {
            colorPalette.gameObject.SetActive(false);
            playerMaterial.SetColor("_Color", defaultColor);
            tuningCameras[0].SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
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
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-300*PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine"));
        }
        else if(whichModConfirmed == 4)
        {
            colorPalette.gameObject.SetActive(false);
            defaultColor = colorPalette.CurrentColor;
            tuningCameras[0].SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-1000);
        }
        UpdateButtons();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
