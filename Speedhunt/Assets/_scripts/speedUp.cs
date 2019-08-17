using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUp : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        Time.timeScale = speed;
    }
    void OnDisable()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
}
