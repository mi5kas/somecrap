using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyAnimation : MonoBehaviour
{
    [SerializeField] string animationName;
    [SerializeField] bool randomizeSpeed;
    [SerializeField] Animator actor = null;
    // Start is called before the first frame update
    void Start()
    {
        if(actor == null)
            actor = this.GetComponent<Animator>();
        if(randomizeSpeed)
        {
            actor.speed = Random.Range(0.5f, 1f);
            actor.CrossFadeInFixedTime(animationName, 1f);
        }
        else
            actor.Play(animationName);
    }
    public void ResetAnimation()
    {
        this.transform.GetChild(0).GetComponent<Animator>().CrossFadeInFixedTime("idle", 1f);
    }
    // Update is called once per fram
}
