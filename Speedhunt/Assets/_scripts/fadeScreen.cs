using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeScreen : MonoBehaviour
{
    [SerializeField] GameObject afterFade;
    [SerializeField] float waitTime = 0f;
    Image fader = null;
    // Start is called before the first frame update
    void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        if(fader == null)
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
            fader.color = new Color(0, 0, 0, 1);
            fader.rectTransform.anchoredPosition = new Vector3(0, 0, 0);
            fader.CrossFadeAlpha(0f, 0.0001f, true);
            RectTransform rect = fader.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.pivot = new Vector2(0.5f, 0.5f);
        }
        
        fader.CrossFadeAlpha(1f, 1f, true);
        Invoke("AfterFade", 2f+waitTime);
    }
    void AfterFade()
    {
        fader.CrossFadeAlpha(0, 1f, true);
        afterFade.SetActive(true);
    }
    // Update is called once per frame
}
