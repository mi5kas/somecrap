using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class _cutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator[] cars;
    [SerializeField] GameObject carsounds;
    [SerializeField] Animator blackBars;
    [SerializeField] GameObject nextCutscene;
    private int whichTake = 0;
    void Start()
    {
        Invoke("StartCutscene", 1f);
        
        
    }
    void StartCutscene()
    {
        this.GetComponent<PlayableDirector>().Play();
    }
    public void PlayTake()
    {
        if(whichTake == 0)
        {
            cars[0].Play("cutscene1");
        }
        else if(whichTake == 1)
        {
            cars[0].Play("cutscene2");
            cars[1].Play("cutscene2");
        }
        else if(whichTake == 2)
        {
            cars[0].Play("cutscene3");
            cars[1].Play("cutscene3");
            cars[2].Play("cutscene3");
        }
        else if(whichTake == 3)
        {
            cars[0].Play("cutscene4");
            cars[1].Play("cutscene4");
            cars[2].Play("cutscene4");
        }
        else if(whichTake == 4)
        {
            cars[2].gameObject.SetActive(false);
            cars[0].enabled = false;
            cars[0].transform.position = new Vector3(139.4808f, 4.55f, 1400.09f);
            cars[0].transform.eulerAngles = Vector3.zero;
            cars[0].gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 5000);
            cars[1].enabled = false;
            cars[1].transform.position = new Vector3(139.4808f, 4.55f, 1390.286f);
            cars[1].transform.eulerAngles = Vector3.zero;
            cars[1].gameObject.GetComponent<RVP.FollowAI>().enabled = true;
            cars[1].gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 5000);
            blackBars.Play("HideIt");
            carsounds.SetActive(false);

        }
        whichTake++;
    }
}
