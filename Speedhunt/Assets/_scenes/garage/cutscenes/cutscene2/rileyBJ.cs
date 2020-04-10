using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class rileyBJ : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] Image guideLine;
    [SerializeField] Transform guidePosition;
    [SerializeField] CinemachineVirtualCamera camera;
    [SerializeField] Animator[] actors;
    [SerializeField] GameObject afterParty;
    [SerializeField] AudioClip[] sounds;
    CinemachinePOV povCamera;
    AudioSource soundEffects;
    bool activeButton = false;
    float orgasm = 0f;
    // Start is called before the first frame update
    void Start()
    {
        povCamera = camera.GetCinemachineComponent<CinemachinePOV>();
        progressBar.transform.parent.parent.gameObject.SetActive(true);
        actors[0].CrossFadeInFixedTime("hjfemale", 1f);
        actors[0].transform.localPosition = new Vector3(-0.67f, -0.93f, 2.63f);
        actors[0].transform.eulerAngles = Vector3.zero;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        soundEffects = GetComponent<AudioSource>();
        soundEffects.clip = sounds[0];
        soundEffects.Play();
        soundEffects.pitch = 0.75f;
    }
    public void MouseDown()
    {
        activeButton = true;
        guideLine.enabled = false;
        povCamera.m_HorizontalAxis.m_MaxSpeed = 0;
        povCamera.m_VerticalAxis.m_MaxSpeed = 0;
    }
    public void MouseExit()
    {
        activeButton = false;
        guideLine.enabled = true;
        actors[0].speed = 1f;
        actors[1].speed = 1f;
        povCamera.m_HorizontalAxis.m_MaxSpeed = 10;
        povCamera.m_VerticalAxis.m_MaxSpeed = 10;
    }
    public void ChangePosition(int whichPosition)
    {
        if(whichPosition == 0)
        {
            actors[0].CrossFadeInFixedTime("hjfemale", 1f);
            actors[1].CrossFadeInFixedTime("hjmale", 1f);
            actors[0].transform.localPosition = new Vector3(-0.67f, -0.93f, 2.63f);
            soundEffects.clip = sounds[0];
            soundEffects.Play();
            soundEffects.pitch = 0.75f;
        }
        else if (whichPosition == 1)
        {
            actors[0].CrossFadeInFixedTime("bjfemale", 1f);
            actors[1].CrossFadeInFixedTime("bjmale", 1f);
            actors[0].transform.localPosition = new Vector3(-0.67f, -0.92f, 2.674f);
            soundEffects.clip = sounds[1];
            soundEffects.Play();
            soundEffects.pitch = 0.75f;
        }
        else if (whichPosition == 2)
        {
            actors[0].CrossFadeInFixedTime("hardfemale", 1f);
            actors[1].CrossFadeInFixedTime("hardmale", 1f);
            actors[0].transform.localPosition = new Vector3(-0.714f, -0.927f, 2.657f);
            soundEffects.clip = sounds[2];
            soundEffects.Play();
            soundEffects.pitch = 0.75f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(activeButton)
        {
            actors[0].speed = 1 + Mathf.Abs(Input.GetAxis("Mouse Y"));
            actors[1].speed = 1 + Mathf.Abs(Input.GetAxis("Mouse Y"));
            soundEffects.pitch = Mathf.Clamp(actors[0].speed*0.5f, 0.9f, 1.1f);
            orgasm += actors[0].speed / (2 / Time.deltaTime);
            progressBar.fillAmount = orgasm / 100;
            if(orgasm >= 100)
            {
                actors[0].CrossFadeInFixedTime("cum", 1f);
                actors[1].CrossFadeInFixedTime("cummale", 1f);
                actors[0].transform.localPosition = new Vector3(-0.714f, -0.927f, 2.657f);
                actors[0].speed = 1f;
                actors[1].speed = 1f;
                activeButton = false;
                progressBar.transform.parent.parent.gameObject.SetActive(false);
                Invoke("endBJ", 5f);
                soundEffects.clip = sounds[3];
                soundEffects.Play();
            }
        }
        else
        {
            guideLine.transform.position = Camera.main.WorldToScreenPoint(guidePosition.position);
        }
    }
    void endBJ()
    {
        afterParty.SetActive(true);
    }
}
