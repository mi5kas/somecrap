using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canyonCutscenes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator enemyCar;
    [SerializeField] Animator playerCar;
    public void PlayAnimation(int which)
    {
        if(which == 0)
        {
            playerCar.Play("player1");
        }
        else if(which == 1)
        {
            playerCar.Play("player2");
            enemyCar.Play("enemy2");
        }
        else if(which == 2)
        {
            playerCar.Play("player3");
            enemyCar.Play("enemy3");
        }
    }
    // Update is called once per frame
}
