using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeAnimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("ChangeAnim", 1f, 1f);
    }
    void ChangeAnim()
    {
        animator.SetInteger("whichAnim", Random.Range(0, 7));
    }
    // Update is called once per fram
}
