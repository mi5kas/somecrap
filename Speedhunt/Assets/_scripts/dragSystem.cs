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
    CinemachineBasicMultiChannelPerlin vcam;
    // Start is called before the first frame update
    void Start()
    {
        playerPower = PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Power");
        enemyPower = enemyCar.GetComponent<carGenerator>().enemyPower;
        InvokeRepeating("SetSpeed", 1f, 0.05f);
        vcam = carCamera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        roadSlider.maxValue = Vector3.Distance(playerCar.transform.position, finishLine.transform.position);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            endRace.transform.parent.gameObject.SetActive(true);
            CancelInvoke();
            playerCar.speed = 1f;
            enemyCar.speed = 1f;
            engineSound.Stop();
            rpmNeedle.transform.parent.parent.gameObject.SetActive(false);
            dragMusic.GetComponent<AudioSource>().volume=1;
            dragMusic.PlayEnding();
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
            if(playerRPM < 6800f)
                playerCar.speed+= 0.07f/gearRatio*playerPower; //Cia greiti nustato pagal apsukas ir dabartini begi
                vcam.m_FrequencyGain = playerCar.speed;
            playerRPM += 1000f*playerPower/(currentGear*gearRatio); //Cia prideda apsukas kas 0.05 sekundes;
            if(playerRPM > 7000f) //REV LIMITER
            {
                playerRPM = 6800f;
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
        rpmNeedle.rotation = Quaternion.Euler(0, 0, 0-200*0.0001f*playerRPM);
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
    void FixedUpdate()
    {
        if(!endRace.transform.parent.gameObject.activeSelf)
            carCamera.localPosition = new Vector3(carCamera.localPosition.x, carCamera.localPosition.y, Mathf.Clamp(Vector3.Distance(enemyCar.transform.position, finishLine.position)-Vector3.Distance(playerCar.transform.position, finishLine.position), -5f, 5f));
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
