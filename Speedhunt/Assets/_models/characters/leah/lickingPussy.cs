using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class lickingPussy : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer girl;
    [SerializeField] Image progressBar;
    [SerializeField] Image[] guideLines;
    [SerializeField] Transform[] guidePositions;
    [SerializeField] CinemachineVirtualCamera cameraTemp;
    CinemachinePOV povCamera;
    int activeButton = 0;
    // Start is called before the first frame update
    void Start()
    {
        povCamera = cameraTemp.GetCinemachineComponent<CinemachinePOV>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void MouseDown(int buttonNumber)
    {
        Debug.Log("Spaudziam");
        activeButton = buttonNumber;
        guideLines[0].enabled = false;
        guideLines[1].enabled = false;
        povCamera.m_HorizontalAxis.m_MaxSpeed = 0;
        povCamera.m_VerticalAxis.m_MaxSpeed = 0;
    }
    public void MouseExit()
    {
        activeButton = 0;
        guideLines[0].enabled = true;
        guideLines[1].enabled = true;
        povCamera.m_HorizontalAxis.m_MaxSpeed = 50;
        povCamera.m_VerticalAxis.m_MaxSpeed = 50;
    }
    // Update is called once per frame
    void Update()
    {
        if(activeButton == 1)
        {
            girl.SetBlendShapeWeight(5, girl.GetBlendShapeWeight(5) + Input.GetAxis("Mouse X"));
        }
        else if(activeButton == 2)
        {
            girl.SetBlendShapeWeight(7, girl.GetBlendShapeWeight(7) + Input.GetAxis("Mouse Y"));
        }
        else
        {
            guideLines[0].transform.position = Camera.main.WorldToScreenPoint(guidePositions[0].position);
            guideLines[1].transform.position = Camera.main.WorldToScreenPoint(guidePositions[1].position);
        }
    }
}
