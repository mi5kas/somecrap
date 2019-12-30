using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyAnimation : MonoBehaviour
{
    [SerializeField] string animationName;
    [SerializeField] bool randomizeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().Play(animationName);
        if(randomizeSpeed)
            this.GetComponent<Animator>().speed = Random.Range(0.5f, 1f);
    }
    public void ResetAnimation()
    {
        this.transform.GetChild(0).GetComponent<Animator>().CrossFadeInFixedTime("idle", 1f);
    }
    // Update is called once per fram
}
