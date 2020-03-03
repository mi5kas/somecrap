using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class blacklist1 : MonoBehaviour
{
    [SerializeField] Animator enemyCar;
    [SerializeField] PlayableDirector cutscene;
    int whichScene = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        whichScene++;
        if(whichScene == 1)
        {
            enemyCar.Play("enemy1");
            this.gameObject.SetActive(false);
        }
        else if(whichScene == 2)
        {
            cutscene.Pause();
            this.gameObject.SetActive(false);
        }
        else
        {
            cutscene.Resume();
            enemyCar.Play("enemy2");
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
 
}
