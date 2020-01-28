using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adjustGarage : MonoBehaviour
{
    [SerializeField] Material garageMaterial;
    [SerializeField] Light directionalLight;
    [SerializeField] Animator jeff;
    [SerializeField] Animator michelle;
    [SerializeField] Renderer sceneCar;
    [SerializeField] GameObject[] cutscenes;

    [SerializeField] Transform playerCar;
    [SerializeField] Text confirmMod;
    [SerializeField] ColorPicker colorPalette;
    [SerializeField] GameObject[] tuningCameras;
    [SerializeField] Text moneyText;
    Material[] playerMaterial = new Material[2];
    [SerializeField] Button[] tuningButtons;
    [SerializeField] Text[] levelTexts;
    [SerializeField] Text[] costTexts;
    [SerializeField] GameObject wheelButtons;
    Material[] wheelsMaterial = new Material[4];
    [SerializeField] RectTransform powerLine;
    [SerializeField] RectTransform handlingLine;
    [SerializeField] Transform[] suspensions;
    [SerializeField] AudioSource repairSound;
    [SerializeField] GameObject endTuning;
    Color defaultColor;
    int currentWheels;
    int whichModConfirmed;
    // Start is called before the first frame update
    void Start()
    {
        UpdateButtons();
        if(PlayerPrefs.GetInt("story", 0) == 3)
        {
            cutscenes[0].SetActive(true);
            sceneCar.gameObject.SetActive(true);
        }
        else
        {
            cutscenes[1].SetActive(true);
            int playAnim = Random.Range(0, 4);
            string[] animationNames = new string[]
            {
                "Bartending",
                "Working On Device",
                "Laying",
                "talking",
                "arguing",
                "phone"
            };
            Vector3[] animationPos = new Vector3[]
            {
                new Vector3(6.35f, -0.763f, 1.844f),
                new Vector3(5.264f, -0.763f, -5.142f),
                new Vector3(8.018f, -0.684f, -2.9f),
                new Vector3(-0.962f, -0.738f, -2.553f),
                new Vector3(-0.742f, -0.738f, -1.304f),
                new Vector3(-1.96f, -0.74f, -3.2f)

            };
            Vector3[] animationRot = new Vector3[]
            {
                new Vector3(0f, 0f, 0f),
                new Vector3(0f, 190f, 0f),
                new Vector3(0f, 180f, 0f),
                new Vector3(0, 10f, 0f),
                new Vector3(0, 190f, 0f),
                new Vector3(0, -135f, 0f)
            };
            if(playAnim == 0 || playAnim == 2)
            {
                sceneCar.transform.parent.gameObject.SetActive(true);
                foreach(Material mat in sceneCar.materials)
                {
                    if(mat.name == "subaru_body (Instance)")
                    {
                        mat.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
                    }
                    else
                    {
                        mat.DisableKeyword("_EMISSION");
                    }
                }
            }
            jeff.Play(animationNames[playAnim]);
            jeff.transform.position = animationPos[playAnim];
            jeff.transform.rotation =  Quaternion.Euler(animationRot[playAnim].x, animationRot[playAnim].y, animationRot[playAnim].z);
            if(playAnim == 4)
            {
                playAnim = 3;
            }
            else if(playAnim == 3)
            {
                playAnim = 4;
            }
            else
            {
                playAnim = Random.Range(0, 3);
            }
            michelle.Play(animationNames[playAnim]);
            michelle.transform.position = animationPos[playAnim];
            michelle.transform.rotation = Quaternion.Euler(animationRot[playAnim].x, animationRot[playAnim].y, animationRot[playAnim].z);
        }
        if(PlayerPrefs.GetInt("isNight", 0) == 0)
        {
            directionalLight.color = new Color(0.5f, 0.5f, 0.5f, 1);
            garageMaterial.SetColor("_EmissionColor", new Color(0.7f, 0.7f, 0.7f, 7f));
        }
        else
        {
            directionalLight.color = new Color(1f, 1f, 1f, 1);
            garageMaterial.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
        }
        int tempCarID = PlayerPrefs.GetInt("currentCar");
        foreach(Material mat in playerCar.GetChild(0).GetChild(tempCarID).GetComponent<Renderer>().materials)
        {
            Debug.Log(playerCar.GetChild(0).GetChild(tempCarID));
            if(mat.name == "carMaterial (Instance)")
            {
                playerMaterial[0] = mat;
            }
        }
        foreach(Material mat in playerCar.GetChild(0).GetChild(tempCarID).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Status")).GetComponent<Renderer>().materials)
        {
            if(mat.name == "carMaterial (Instance)")
            {
                playerMaterial[1] = mat;
            }
        }
        for(int i=0; i<4; i++)
        {
            foreach(Material mat in playerCar.GetChild(4+i).GetChild(0).GetChild(0).GetChild(PlayerPrefs.GetInt("car" + tempCarID + "Wheels")).GetComponent<Renderer>().materials)
            {
                if(mat.name == "wheelMaterial (Instance)")
                {
                    wheelsMaterial[i] = mat;
                }
            }
        }
    }
    public void Tuning(int whichMod)
    {
        whichModConfirmed = whichMod;
        tuningButtons[0].transform.parent.gameObject.SetActive(false);
        if(whichMod == 0)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "<color=#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")+1 + " </color>engine upgrade will increase your power by <color=#2eacd5ff>" + (10+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")) + "%</color>. This upgrade costs <color=#2eacd5ff>" + 300*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Engine")+1) + "$</color>. Do you wish to proceed?";
        }
        else if(whichMod == 1)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "<color=#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")+1 + " </color>suspension upgrade will increase your drifting by <color=#2eacd5ff>" + (5+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")) + "%</color>. This upgrade costs <color=#2eacd5ff>" + 200*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Suspension")+1) + "$</color>. Do you wish to proceed?";
        }
        else if(whichMod == 2)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "<color=#2eacd5ff>LEVEL " + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")+1 + " </color>nitrous upgrade will increase your nitrous boost time by <color=#2eacd5ff>" + (1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")) + "s</color>. This upgrade costs <color=#2eacd5ff>" + 400*(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")+1) + "$</color>. Do you wish to proceed?";
        }
        else if(whichMod == 3)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "Removing all rust and body damage will increase your reputation gain by 20%. It costs <color=#2eacd5ff>1000$</color>. Do you wish to proceed?";
        }
        else if(whichMod == 4)
        {
            tuningCameras[0].SetActive(true);
            colorPalette.gameObject.SetActive(true);
            powerLine.transform.parent.gameObject.SetActive(false);
            handlingLine.transform.parent.gameObject.SetActive(false);
            defaultColor = playerMaterial[0].GetColor("_Color");
            colorPalette.CurrentColor = playerMaterial[0].GetColor("_Color");
            tuningButtons[0].transform.parent.gameObject.SetActive(false);
        }
        else if(whichMod == 5)
        {
            confirmMod.transform.parent.gameObject.SetActive(true);
            confirmMod.text = "This will apply a body kit on your car. Your reputation gains will increase by 20%. This modification costs <color = #2eacd5ff>1000$</color>. Do you wish to proceed?";
            playerCar.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(2).gameObject.SetActive(true);
            playerCar.GetChild(0).GetChild(PlayerPrefs.GetInt("currentCar")).GetChild(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status")).gameObject.SetActive(false);
        }
        else if(whichMod == 6)
        {
            tuningCameras[1].SetActive(true);
            wheelButtons.SetActive(true);
            powerLine.transform.parent.gameObject.SetActive(false);
            handlingLine.transform.parent.gameObject.SetActive(false);
            currentWheels = PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Wheels");
        }
        else if(whichMod == 7)
        {
            tuningCameras[1].SetActive(true);
            colorPalette.gameObject.SetActive(true);
            powerLine.transform.parent.gameObject.SetActive(false);
            handlingLine.transform.parent.gameObject.SetActive(false);
            colorPalette.CurrentColor = wheelsMaterial[0].GetColor("_Color");
        }
        else
        {
            endTuning.SetActive(false);
            endTuning.SetActive(true);
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
        {
            playerMaterial[0].SetColor("_Color", colorPalette.CurrentColor);
            playerMaterial[1].SetColor("_Color", colorPalette.CurrentColor);
        }
        else
        {
            wheelsMaterial[0].SetColor("_Color", colorPalette.CurrentColor);
            wheelsMaterial[1].SetColor("_Color", colorPalette.CurrentColor);
            wheelsMaterial[2].SetColor("_Color", colorPalette.CurrentColor);
            wheelsMaterial[3].SetColor("_Color", colorPalette.CurrentColor);
        }
    }
    public void RejectTuning()
    {
        if(whichModConfirmed < 4)
        {
            confirmMod.transform.parent.gameObject.SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
        }
        else if(whichModConfirmed == 4)
        {
            colorPalette.gameObject.SetActive(false);
            playerMaterial[0].SetColor("_Color", defaultColor);
            playerMaterial[1].SetColor("_Color", defaultColor);
            tuningCameras[0].SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
        }
        else if(whichModConfirmed == 5)
        {
            confirmMod.transform.parent.gameObject.SetActive(false);
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
            wheelsMaterial[0].SetColor("_Color", new Color(PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor1"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor2"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelsColor3"), 1));
            tuningCameras[1].SetActive(false);
            tuningButtons[0].transform.parent.gameObject.SetActive(true);
            colorPalette.gameObject.SetActive(false);
        }
        powerLine.transform.parent.gameObject.SetActive(true);
        handlingLine.transform.parent.gameObject.SetActive(true);
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
        if(currentMoney < 400*(1+PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Nitrous")) || PlayerPrefs.GetInt("story", 0) < 10)
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
            Debug.Log(currentMoney + PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Wheels") == 0);
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
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-1000);
        }
        else if(whichModConfirmed == 4)
        {
            colorPalette.gameObject.SetActive(false);
            if(colorPalette.CurrentColor != new Color(PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Color1"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Color2"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Color3"), 1))
            {
                defaultColor = colorPalette.CurrentColor;
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Color1", defaultColor.r);
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Color2", defaultColor.g);
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Color3", defaultColor.b);
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-800);
            }
            tuningCameras[0].SetActive(false);
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
            if(colorPalette.CurrentColor != new Color(PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelColor1"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelColor2"), PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelColor3"), 1))
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")-200);
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelColor1", colorPalette.CurrentColor.r);
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelColor2", colorPalette.CurrentColor.g);
                PlayerPrefs.SetFloat("car" + PlayerPrefs.GetInt("currentCar") + "WheelColor3", colorPalette.CurrentColor.b);
            }
        }
        UpdateButtons();
        repairSound.Play();
        powerLine.transform.parent.gameObject.SetActive(true);
        handlingLine.transform.parent.gameObject.SetActive(true);
        tuningButtons[0].transform.parent.gameObject.SetActive(true);
    }
}
