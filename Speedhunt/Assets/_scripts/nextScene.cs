using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    Image fader;
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = new GameObject("fader Canvas");
        canvas.AddComponent<RectTransform>();
        canvas.AddComponent<Canvas>();
        CanvasScaler scaler = canvas.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920f, 1080f);
        scaler.matchWidthOrHeight = 0.5f;
        canvas.AddComponent<GraphicRaycaster>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        GameObject faderObj = new GameObject("fader");
        canvas.transform.parent = this.transform;
        faderObj.transform.parent = canvas.transform;
        fader = faderObj.AddComponent<Image>();
        fader.color = new Color(0, 0, 0, 0);
        RectTransform rect = fader.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);
        rect.pivot = new Vector2(0.5f, 0.5f);
        fader.CrossFadeAlpha(1f, 1f, true);
        StartCoroutine(FadeSound());
        DontDestroyOnLoad(this);
    }
    IEnumerator FadeSound()
    {
        fader.CrossFadeAlpha(1, 2f, true);
        AudioListener.volume=1f;
        while(AudioListener.volume > 0)
        {
            AudioListener.volume-=0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Time.timeScale=0;
        SceneManager.LoadScene(sceneNumber);
        yield return new WaitForSeconds(2f);
        Time.timeScale=1;
        fader.CrossFadeAlpha(0, 2f, true);
        while(AudioListener.volume < 1)
        {
            AudioListener.volume+=0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(this);
    }
    // Update is called once per frame
}
