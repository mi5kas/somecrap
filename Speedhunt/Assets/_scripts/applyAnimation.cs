using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyAnimation : MonoBehaviour
{
    [SerializeField] string animationName;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().Play(animationName);
    }
    public void ResetAnimation()
    {
        this.transform.GetChild(0).GetComponent<Animator>().CrossFadeInFixedTime("idle", 1f);
    }
    // Update is called once per fram
}
