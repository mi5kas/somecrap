using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMouse : MonoBehaviour
{
    [SerializeField] bool show;
    // Start is called before the first frame update
    void Start()
    {
        OnEnable();
    }

    // Update is called once per frame
    void OnEnable()
    {
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = show;
    }
}
