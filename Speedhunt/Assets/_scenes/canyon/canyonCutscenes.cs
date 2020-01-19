using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RVP;

public class canyonCutscenes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator enemyCar;
    [SerializeField] Animator playerCar;
    [SerializeField] Transform objects;
    int which = 0;
    void OnEnable()
    {
        if(which == 0)
        {
            playerCar.Play("enemy1", 0);
        }
        else if(which == 1)
        {
            playerCar.Play("player2", 0);
            enemyCar.Play("enemy2", 0);
        }
        else if(which == 2)
        {
            playerCar.Play("player3", 0);
            enemyCar.Play("enemy3", 0);
        }
        else if(which == 3)
        {
            objects.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            playerCar.enabled = false;
            playerCar.GetComponent<BasicInput>().enabled=true;
            playerCar.GetComponent<speedometer>().enabled=true;
            playerCar.transform.position = new Vector3(552.15f, 503.6f, 239.35f);
            playerCar.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerCar.transform.eulerAngles = new Vector3(0, 90f, 0);
            playerCar.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*2000);
            enemyCar.Play("canyonEnemy", 0);
            enemyCar.speed = 0.7f;
        }
        else if(which == 4)
        {
            enemyCar.speed=1f;
            playerCar.Play("playerCrash", 0);
            enemyCar.Play("enemyCrash", 0);
            PlayerPrefs.SetInt("story", 5);
            playerCar.GetComponent<BasicInput>().enabled=false;
            playerCar.enabled = true;
            objects.localScale = new Vector3(1, 1, 1);
        }
        which++;
    }
    // Update is called once per frame
}
