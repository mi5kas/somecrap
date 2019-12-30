using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class choices : MonoBehaviour
{
    [SerializeField] Font ubuntu;
    [SerializeField] string[] buttonTexts;
    [SerializeField] GameObject[] afterButton;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        //OnEnable();
    }
    void OnEnable()
    {
        canvas = new GameObject("choices Canvas");
        canvas.AddComponent<RectTransform>();
        canvas.AddComponent<Canvas>();
        CanvasScaler scaler = canvas.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920f, 1080f);
        scaler.matchWidthOrHeight = 0.5f;
        canvas.AddComponent<GraphicRaycaster>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

        GameObject button1 = new GameObject("button1");
        button1.transform.parent = canvas.transform;
        Text button1Text = button1.AddComponent<Text>();
        button1.AddComponent<Outline>();
        Button button = button1.AddComponent<Button>();
        RectTransform rect = button1.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector3(-500f, -340f, 0);
        rect.sizeDelta = new Vector2(500f, 50f);
        button1Text.font = ubuntu;
        button1Text.text = buttonTexts[0];
        button1Text.fontSize = 30;
        button1Text.alignment = TextAnchor.MiddleCenter;
        button.targetGraphic = button1Text;
        ColorBlock cb = button.colors;
        cb.normalColor = new Color(1, 1, 1, 0.5f);
        cb.highlightedColor = new Color(1,1,1,1);
        button.colors = cb;
        button.onClick.AddListener(() => ButtonClicked(0));

        button1 = new GameObject("button1");
        button1.transform.parent = canvas.transform;
        button1Text = button1.AddComponent<Text>();
        button1.AddComponent<Outline>();
        button = button1.AddComponent<Button>();
        rect = button1.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector3(500f, -340f, 0);
        rect.sizeDelta = new Vector2(500f, 50f);
        button1Text.font = ubuntu;
        button1Text.text = buttonTexts[1];
        button1Text.fontSize = 30;
        button1Text.alignment = TextAnchor.MiddleCenter;
        button.targetGraphic = button1Text;
        cb = button.colors;
        cb.normalColor = new Color(1, 1, 1, 0.5f);
        cb.highlightedColor = new Color(1,1,1,1);
        button.colors = cb;
        button.onClick.AddListener(() => ButtonClicked(1));

        button1 = new GameObject("button1");
        button1.transform.parent = canvas.transform;
        button1Text = button1.AddComponent<Text>();
        button1.AddComponent<Outline>();
        button = button1.AddComponent<Button>();
        rect = button1.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector3(0f, -440f, 0);
        rect.sizeDelta = new Vector2(500f, 50f);
        button1Text.font = ubuntu;
        button1Text.text = buttonTexts[2];
        button1Text.fontSize = 30;
        button1Text.alignment = TextAnchor.MiddleCenter;
        button.targetGraphic = button1Text;
        cb = button.colors;
        cb.normalColor = new Color(1, 1, 1, 0.5f);
        cb.highlightedColor = new Color(1,1,1,1);
        button.colors = cb;
        button.onClick.AddListener(() => ButtonClicked(2));

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void ButtonClicked(int whichButton)
    {
        Debug.Log(whichButton);
        afterButton[whichButton].SetActive(false);
        afterButton[whichButton].SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(canvas);
    }
    // Update is called once per frame
}
