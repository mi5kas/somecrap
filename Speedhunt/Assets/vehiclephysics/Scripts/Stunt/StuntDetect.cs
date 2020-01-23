using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

namespace RVP
{
    [RequireComponent(typeof(VehicleParent))]
    [DisallowMultipleComponent]
    [AddComponentMenu("RVP/Stunt/Stunt Detector", 1)]

    //Class for detecting stunts
    public class StuntDetect : MonoBehaviour
    {
        Transform tr;
        Rigidbody rb;
        VehicleParent vp;

        [System.NonSerialized]
        public float score;
        List<Stunt> stunts = new List<Stunt>();
        List<Stunt> doneStunts = new List<Stunt>();
        bool drifting;
        float driftDist;
        float driftScore=0;
        float endDriftTime;//Time during which drifting counts even if the vehicle is not actually drifting
        float jumpDist;
        float jumpTime;
        Vector3 jumpStart;
        float driftScoreRate;

        bool detectDrift = true;
        [SerializeField] Text totalScore;
        [SerializeField] Text timeLeft;
        [SerializeField] Text currentScore;
        [SerializeField] TextMeshPro endDrift;
        [SerializeField] GameObject backToMap;
        [SerializeField] racemusic racemusic;
        string driftString;//String indicating drift distance
        string jumpString;//String indicating jump distance
        string flipString;//String indicating flips
        [System.NonSerialized]
        public string stuntString;//String containing all stunts

        public Motor engine;
        int timeRemaining=60;

        void Start()
        {
            tr = transform;
            rb = GetComponent<Rigidbody>();
            vp = GetComponent<VehicleParent>();
            totalScore.transform.parent.gameObject.SetActive(true);
            timeLeft.transform.parent.gameObject.SetActive(true);
            InvokeRepeating("Countdown", 1f, 1f);
            driftScoreRate=0.01f+PlayerPrefs.GetFloat("car" + PlayerPrefs.GetInt("currentCar") + "Handling")/10;
            if(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status", 0) == 0)
            {
                driftScoreRate=0.08f;
            }
            else if(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status", 0) == 1)
            {
                driftScoreRate=0.1f;
            }
            else if(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status", 0) == 1)
            {
                driftScoreRate=0.1f;
            }
        }
        void Countdown()
        {
            timeRemaining-=1;
            timeLeft.text = "0:" + timeRemaining;
            if(timeRemaining == 0)
            {
                endDrift.transform.parent.gameObject.SetActive(true);
                this.GetComponent<BasicInput>().enabled=false;
                currentScore.gameObject.SetActive(false);
                timeLeft.transform.parent.gameObject.SetActive(false);
                totalScore.transform.parent.gameObject.SetActive(false);
                rb.velocity = Vector3.zero;
                vp.SetEbrake(1);
                score+=driftScore;
                racemusic.PlayEnding();
                if(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status", 0) == 0)
                {
                    driftScoreRate=0.08f;
                }
                else if(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status", 0) == 1)
                {
                    driftScoreRate=0.1f;
                }
                else if(PlayerPrefs.GetInt("car" + PlayerPrefs.GetInt("currentCar") + "Status", 0) == 2)
                {
                    driftScoreRate=0.12f;
                }
                PlayerPrefs.SetInt("reputation", PlayerPrefs.GetInt("reputation", 0) + Mathf.RoundToInt(score*driftScoreRate));
                PlayerPrefs.SetInt("northtownRep", Mathf.Clamp(PlayerPrefs.GetInt("northtownRep", 0) + Mathf.RoundToInt(score*driftScoreRate), 0, 4000));

                endDrift.text = Mathf.RoundToInt(score*driftScoreRate) + "\n\n" + PlayerPrefs.GetInt("reputation", 0);
                this.GetComponent<speedometer>().enabled=false;
                detectDrift=false;
            }
        }
        void FixedUpdate()
        {
            //Detect drifts
            if (detectDrift && !vp.crashing)
            {
                DetectDrift();
            }
            else
            {
                drifting = false;
                driftDist = 0;
                driftScore = 0;
                driftString = "";
            }
            if(!detectDrift && Input.GetKeyDown(KeyCode.Return))
            {
                backToMap.SetActive(true);
            }
            //Detect jumps

            //Detect flips

            //Combine strings into final stunt string
            stuntString = vp.crashing ? "Crashed" : driftString + jumpString + (string.IsNullOrEmpty(flipString) || string.IsNullOrEmpty(jumpString) ? "" : " + ") + flipString;
        }

        void DetectDrift()
        {
            endDriftTime = vp.groundedWheels > 0 ? (Mathf.Abs(vp.localVelocity.x) > 5 ? StuntManager.driftConnectDelayStatic : Mathf.Max(0, endDriftTime - Time.timeScale * TimeMaster.inverseFixedTimeFactor)) : 0;
            drifting = endDriftTime > 0;

            if (drifting)
            {
                driftScore += (driftScoreRate * Mathf.Abs(vp.localVelocity.x)) * Time.timeScale * TimeMaster.inverseFixedTimeFactor;
                driftDist += vp.velMag * Time.fixedDeltaTime;
                string driftText = "GOOD DRIFT";
                currentScore.gameObject.SetActive(true);
                if(driftScore < 10)
                {
                    driftText = "GOOD DRIFT";
                }
                else if(driftScore < 30)
                {
                    driftText = "GREAT DRIFT!";
                }
                else if(driftScore < 60)
                {
                    driftText = "FANTASTIC!";
                }
                else if(driftScore < 120)
                {
                    driftText = "OH MY GOD!";
                }
                else if(driftScore < 200)
                {
                    driftText = "I'M GONNA CUM!";
                }
                else
                {
                    driftText = "AAAAAAHHHHHHHHH";
                }
                currentScore.text = driftText +"\n" + Mathf.RoundToInt(driftScore*10);

                if (engine)
                {
                    engine.boost += (StuntManager.driftBoostAddStatic * Mathf.Abs(vp.localVelocity.x)) * Time.timeScale * 0.0002f * TimeMaster.inverseFixedTimeFactor;
                }
            }
            else
            {
                score += driftScore*10;
                totalScore.text = Mathf.RoundToInt(score).ToString();
                currentScore.gameObject.SetActive(false);
                driftDist = 0;
                driftScore = 0;
                driftString = "";
            }
        }

        
    }
}