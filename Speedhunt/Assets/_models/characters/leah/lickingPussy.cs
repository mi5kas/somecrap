using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class lickingPussy : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer girl;
    [SerializeField] Image progressBar;
    [SerializeField] Image guideLines;
    [SerializeField] Transform guidePositions;
    [SerializeField] CinemachineVirtualCamera cameraTemp;
    [SerializeField] Animator animator;
    CinemachinePOV povCamera;
    bool activeButton = false;
    float orgasm = 0f;
    // Start is called before the first frame update
    void Start()
    {
        povCamera = cameraTemp.GetCinemachineComponent<CinemachinePOV>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    public void MouseDown(int buttonNumber)
    {
        activeButton = true;
        guideLines.enabled = false;
        povCamera.m_HorizontalAxis.m_MaxSpeed = 0;
        povCamera.m_VerticalAxis.m_MaxSpeed = 0;
        animator.CrossFadeInFixedTime("licking", 0.5f);
    }
    public void MouseExit()
    {
        activeButton = false;
        guideLines.enabled = true;
        povCamera.m_HorizontalAxis.m_MaxSpeed = 50;
        povCamera.m_VerticalAxis.m_MaxSpeed = 50;
        animator.CrossFadeInFixedTime("lickyIdle", 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        if(activeButton)
        {
            orgasm += (Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y")))/(1f/Time.deltaTime);
            progressBar.fillAmount = orgasm / 100f;
            girl.SetBlendShapeWeight(5, Mathf.Clamp((girl.GetBlendShapeWeight(5) + Input.GetAxis("Mouse X")*-1), 0f, 100f));
            girl.SetBlendShapeWeight(7, Mathf.Clamp(girl.GetBlendShapeWeight(7) + Input.GetAxis("Mouse Y"), 0f, 100f));
            if(orgasm >= 100)
            {
                activeButton = false;
                guideLines.gameObject.SetActive(false);
                guidePositions.gameObject.SetActive(false);
                progressBar.transform.parent.parent.gameObject.SetActive(false);
                povCamera.m_HorizontalAxis.m_MaxSpeed = 50;
                povCamera.m_VerticalAxis.m_MaxSpeed = 50;
                animator.CrossFadeInFixedTime("cumming", 1f);
            }
        }
        else
        {
            guideLines.transform.position = Camera.main.WorldToScreenPoint(guidePositions.position);
        }
    }
}
