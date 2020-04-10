using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rileyBJ_Button : MonoBehaviour
{
    [SerializeField] rileyBJ mainScript;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnMouseDown()
    {
        if(mainScript.gameObject.activeSelf)
            mainScript.MouseDown();
    }
    private void OnMouseUp()
    {
        if (mainScript.gameObject.activeSelf)
            mainScript.MouseExit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
