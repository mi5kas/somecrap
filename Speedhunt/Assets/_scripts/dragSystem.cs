using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class dragSystem : MonoBehaviour
{
    [SerializeField] Animator playerCar;
    [SerializeField] Animator enemyCar;
    [SerializeField] Transform rpmNeedle;
    [SerializeField] Text speedText;
    [SerializeField] Transform carCamera;
    [SerializeField] Transform finishLine;
    [SerializeField] AudioSource engineSound;
    [SerializeField] AudioSource shiftingSound;
    [SerializeField] AudioSource enemySound;
    [SerializeField] Text shiftText;
    [SerializeField] Text timeText;
    [SerializeField] Slider roadSlider;
    [SerializeField] TextMeshPro endRace;
    [SerializeField] TextMeshPro resultText;
    [SerializeField] racemusic dragMusic;
    [SerializeField] GameObject backToMap;
    [SerializeField] Button shiftButton;
    [SerializeField] Button gasButton;
    [SerializeField] GameObject nosSystem;
    float playerRPM=1000f;
    int currentGear=1;
    float playerPower = 0.3f;
    float enemyPower;
    float gearRatio = 1;
    float enemyRPM;
    float enemyGear = 1;
    float enemyRatio = 1;
    float shifting = 0;
    float currentTime = 0;
    bool raceWon = true;

    bool revving = false;
    CinemachineBasicMultiChannelPerlin vcam;
    // Start is called before the first frame update
    void Start()
    {
        playerPower = PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Power");
        enemyPower = enemyCar.GetComponent<carGenerator>().enemyPower;
        vcam = carCamera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        roadSlider.maxValue = Vector3.Distance(playerCar.transform.position, finishLine.transform.position);
        rpmNeedle.transform.parent.gameObject.SetActive(true);
        InvokeRepeating("Rev", 1f, 0.05f);
        Invoke("StartRace", 4f);
    }
    void StartRace()
    {
        CancelInvoke();
        InvokeRepeating("SetSpeed", 1f, 0.05f);
        playerCar.Play("playerStart");
        enemyCar.Play("enemyStart");
        revving = true;
        gasButton.interactable = false;
        if(playerRPM > 7000)
        {
            playerCar.speed = 0.8f;
        }
        else if(playerRPM < 5000)
        {
            playerCar.speed = 1f;
        }
        else
        {
            playerCar.speed = 1.2f;
        }
    }
    void Rev()
    {
        if(revving)
        {
            playerRPM += 300f;
        }
        else
        {
            playerRPM -= 150f;
        }
        if(playerRPM > 8000)
        {
            playerRPM = 7000;
        }
        else if(playerRPM < 1000)
        {
            playerRPM = 1000;
        }
        rpmNeedle.rotation = Quaternion.Euler(0, 0, 100 - 160 * 0.001f * playerRPM/8);
        engineSound.pitch = 0.3f + 1f * playerRPM / 6000;
        engineSound.volume = 0.3f + 0.6f * playerRPM / 7000;
    }
    public void RevUp()
    {
        revving = true;
    }
    public void RevDown()
    {
        if(gasButton.interactable)
            revving = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.name == "playerCar")
        {
            endRace.transform.parent.gameObject.SetActive(true);
            CancelInvoke();
            playerCar.speed = 1f;
            enemyCar.speed = 1f;
            engineSound.Stop();
            rpmNeedle.transform.parent.gameObject.SetActive(false);
            dragMusic.GetComponent<AudioSource>().volume=1;
            dragMusic.PlayEnding();
            carCamera.gameObject.SetActive(false);
            if(raceWon)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0)+200);
                endRace.text = currentTime.ToString("0.00") + "s\n\n200";
                resultText.text = "VICTORY";
            }
            else
            {
                endRace.text = currentTime.ToString("0.00") + "s\n\n0";
                resultText.text = "DEFEAT";
            }
        }
        else
        {
            raceWon=false;
        }
    }
    void SetSpeed()
    {
        if(shifting <= 0)
        {
            if(playerRPM < 7000f)
                playerCar.speed+= 0.07f/gearRatio*playerPower; //Cia greiti nustato pagal apsukas ir dabartini begi
                vcam.m_FrequencyGain = playerCar.speed;
            if(revving)
            {
                playerRPM -= 200;
                Debug.Log(playerRPM);
                if (playerRPM <= 3000)
                {
                    revving = false;
                }
            }
            else
                playerRPM += 1000f*playerPower/(currentGear*gearRatio); //Cia prideda apsukas kas 0.05 sekundes;
            if(playerRPM > 8000f) //REV LIMITER
            {
                playerRPM = 7500f;
            }
        }
        else
        {
            shifting-=500;
            playerRPM-=500;
        }
        if(currentGear == 1)
            engineSound.pitch = 0.5f+1f*playerRPM/(1.7f)/4000;
        else
            engineSound.pitch = 0.5f+1f*playerRPM/(gearRatio)/4000;
        engineSound.volume = 0.3f+0.6f*playerRPM/7000;
        enemyRPM += 1000f*enemyPower/(enemyGear*enemyRatio);
        rpmNeedle.rotation = Quaternion.Euler(0, 0, 100 - 160 * 0.001f * playerRPM / 8);
        enemyCar.speed+= 0.07f/enemyRatio*enemyPower;
        roadSlider.value = roadSlider.maxValue - Vector3.Distance(playerCar.transform.position, finishLine.transform.position);
        enemySound.pitch = 0.5f+1f*enemyRPM/(enemyRatio)/4000;
        speedText.text = (Mathf.RoundToInt(50f*playerCar.speed)).ToString();
        currentTime+=0.05f;
        timeText.text = currentTime.ToString("0.00");
        if(enemyRPM > 5000f)
        {
            enemyRPM-=2000;
            enemyGear++;
            enemyRatio = enemyRatio*1.75f;
        }
    }
    void Update()
    {
        Debug.Log(Vector3.Distance(enemyCar.transform.position, finishLine.position) - Vector3.Distance(playerCar.transform.position, finishLine.position));
        if(!endRace.transform.parent.gameObject.activeSelf)
            carCamera.localPosition = new Vector3(carCamera.localPosition.x, carCamera.localPosition.y, Mathf.Clamp((Vector3.Distance(enemyCar.transform.position, finishLine.position)-Vector3.Distance(playerCar.transform.position, finishLine.position)), -5f, 5f));
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            backToMap.SetActive(true);
        }

    }
    public void ShiftGear() //MYGTUKAS KEICIA PAVARAS
    {
        if(currentGear != 5 && playerRPM > 4000)
        {
            shiftingSound.Play();
            shiftText.gameObject.SetActive(false);
            shiftText.gameObject.SetActive(true);
            if(playerRPM < 5000)
                shiftText.text = "EARLY SHIFT";
            else if(playerRPM < 6000)
            {
                shiftText.text = "GOOD SHIFT";
            }
            else if(playerRPM < 6800)
            {
                shiftText.text = "PERFECT SHIFT";
            }
            else
                shiftText.text = "LATE SHIFT";
            currentGear++;
            /*if(currentGear == 2)
            {
                gearRatio=1.75f;
            }
            else if(currentGear == 3)
            {
                gearRatio=3f;
            }
            else if(currentGear == 4)
            {
                gearRatio=5.25f;
            }*/
            gearRatio = gearRatio*1.75f;
            shifting = 3000;
        }
    }
}
