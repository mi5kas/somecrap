using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutscene1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float time = 3f;
    [SerializeField] Animator mia;
    Image fader;
    void Start()
    {
        OnEnable();
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
        RectTransform rect = fader.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector3(0,0,0);
        fader.CrossFadeAlpha(0, 1f, true);
    }
    void OnEnable()
    {
        Invoke("ShowDialogue", time);
    }
    void ShowDialogue()
    {
        mia.CrossFadeInFixedTime("sitting2", 2f, 0);
        this.GetComponent<dialogs>().enabled=false;
        this.GetComponent<dialogs>().enabled=true;
        Destroy(fader.transform.parent.gameObject);
    }
    // Update is called once per frame
}
