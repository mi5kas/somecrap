using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setPlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerObject;
    [SerializeField] RawImage fader = null;
    [SerializeField] string animationName = "";
    void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        if(fader != null)
        {
            Invoke("SetPlayerPos", 2f);
            fader.CrossFadeAlpha(1, 1f, false);
        }
        else
        {
            SetPlayerPos();
        }
    }
    // Update is called once per frame
    void SetPlayerPos()
    {
        if(fader != null)
            fader.CrossFadeAlpha(0, 1f, false);
        if(animationName != "")
            playerObject.GetComponent<Animator>().Play(animationName, -1);
        playerObject.transform.position = this.transform.position;
        playerObject.transform.rotation = this.transform.rotation;
    }
}
