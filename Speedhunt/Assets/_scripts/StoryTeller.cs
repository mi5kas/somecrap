using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class StoryTeller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject scene5;
    [SerializeField] GameObject menuObject;
    [SerializeField] PostProcessProfile pProfile;
    void Start()
    {
        if(PlayerPrefs.GetInt("story", 0) >= 200)
        {
            scene5.SetActive(true);
        }
        else
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("currentCar", 4);
            PlayerPrefs.SetFloat("car0Color1", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car0Color2", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car0Color3", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car0Power", 0.3f);
            PlayerPrefs.SetFloat("car0Handling", 0.3f);
            PlayerPrefs.SetFloat("car1Color1", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car1Color2", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car1Color3", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car1Power", 0.3f);
            PlayerPrefs.SetFloat("car1Handling", 0.3f);
            PlayerPrefs.SetFloat("car2Color1", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car2Color2", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car2Color3", Random.Range(0f, 1f));
            PlayerPrefs.SetFloat("car2Power", 0.3f);
            PlayerPrefs.SetFloat("car2Handling", 0.3f);
        }
        if(QualitySettings.GetQualityLevel() == 2)
        {
            Bloom bloomSetting;
            AmbientOcclusion ambientSetting;
            MotionBlur motionSetting;
            pProfile.TryGetSettings(out bloomSetting);
            pProfile.TryGetSettings(out ambientSetting);
            pProfile.TryGetSettings(out motionSetting);
            bloomSetting.enabled.value = true;
            ambientSetting.enabled.value = true;
            motionSetting.enabled.value = true;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void ResumeGame()
    {
        menuObject.SetActive(false);
        Time.timeScale=1f;
        Cursor.visible=false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape") && !Cursor.visible)
        {
            if(menuObject.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                menuObject.SetActive(true);
                Time.timeScale=0f;
                Cursor.visible=true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
