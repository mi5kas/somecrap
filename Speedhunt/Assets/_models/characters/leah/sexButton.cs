using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sexButton : MonoBehaviour
{
    [SerializeField] lickingPussy mainScript;
    [SerializeField] int buttonID;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnMouseDown()
    {
        mainScript.MouseDown(buttonID);
    }
    private void OnMouseUp()
    {
        mainScript.MouseExit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
