using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lickingPussy : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer girl;
    [SerializeField] Image progressBar;
    [SerializeField] RectTransform[] guideLines;

    int activeButton = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MouseDown(int buttonNumber)
    {
        activeButton = buttonNumber;
    }
    public void MouseExit()
    {
        activeButton = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(activeButton == 1)
        {
            girl.SetBlendShapeWeight(5, girl.GetBlendShapeWeight(5) + Input.GetAxis("Mouse X")/10);
        }
        else if(activeButton == 2)
        {
            girl.SetBlendShapeWeight(7, girl.GetBlendShapeWeight(7) + Input.GetAxis("Mouse Y")/10);
        }
    }
}
