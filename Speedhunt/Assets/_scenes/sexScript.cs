using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sexScript : MonoBehaviour
{
    [SerializeField] lickingPussy scriptas;
    [SerializeField] int buttonID;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnMouseDown()
    {
        scriptas.MouseDown(buttonID);
    }
    private void OnMouseUp()
    {
        scriptas.MouseExit();
    }
}
