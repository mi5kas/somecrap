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
    [SerializeField] AudioSource moaning;
    [SerializeField] AudioClip[] moaningSounds;
    CinemachinePOV povCamera;
    bool activeButton = false;
    float orgasm = 0f;
    // Start is called before the first frame update
    void Start()
    {
        povCamera = cameraTemp.GetCinemachineComponent<CinemachinePOV>();
        animator.transform.position = new Vector3(-24.818f, 24.247f, -24.865f);
        animator.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        moaning.gameObject.SetActive(true);
        moaning.clip = moaningSounds[0];
        moaning.Play();
    }
    public void MouseDown(int buttonNumber)
    {
        activeButton = true;
        guideLines.enabled = false;
        povCamera.m_HorizontalAxis.m_MaxSpeed = 0;
        povCamera.m_VerticalAxis.m_MaxSpeed = 0;
        animator.CrossFadeInFixedTime("licking", 0.5f);
        moaning.clip = moaningSounds[1];
        moaning.Play();
    }
    public void MouseExit()
    {
        activeButton = false;
        guideLines.enabled = true;
        povCamera.m_HorizontalAxis.m_MaxSpeed = 50;
        povCamera.m_VerticalAxis.m_MaxSpeed = 50;
        animator.CrossFadeInFixedTime("lickyIdle", 0.5f);
        moaning.clip = moaningSounds[0];
        moaning.Play();
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
                moaning.clip = moaningSounds[2];
                moaning.Play();
            }
        }
        else
        {
            guideLines.transform.position = Camera.main.WorldToScreenPoint(guidePositions.position);
        }
    }
}
