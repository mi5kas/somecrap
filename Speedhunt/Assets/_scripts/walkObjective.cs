using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walkObjective : MonoBehaviour
{
    [SerializeField] GameObject toActivate;
    Image fader;
    [SerializeField] Font font;
    Text textMesh;
    // Start is called before the first frame update
    void Start()
    {
        CreateObjective();
    }

    // Update is called once per frame
    void CreateObjective()
    {
        if(font != null)
        {
            GameObject canvas = new GameObject("objective Canvas");
            canvas.AddComponent<RectTransform>();
            canvas.AddComponent<Canvas>();
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<GraphicRaycaster>();
            canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.transform.parent = this.transform;
            GameObject childObj = new GameObject();
            //Make block to be parent of this gameobject
            childObj.transform.parent = canvas.transform;
            childObj.name = "objective Text";
            //Create TextMesh and modify its properties
            textMesh = childObj.AddComponent<Text>();
            textMesh.fontSize = 20;
            textMesh.rectTransform.localPosition = Vector3.zero;
            textMesh.rectTransform.sizeDelta = new Vector2(300f, 30f);
            textMesh.alignment = TextAnchor.MiddleCenter;
            textMesh.font = font;
        }
    }
    void Update()
    {
        if(font)
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {
                textMesh.gameObject.SetActive(true);
                float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
                Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
                textMesh.text = "OBJECTIVE " + Mathf.RoundToInt(distance) + "M";
                textMesh.transform.position = namePose;
            }
            else
            {
                textMesh.gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(toActivate)
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
            fader.color = new Color(0, 0, 0, 1f);
            fader.CrossFadeAlpha(0f, 0.01f, true);
            RectTransform rect = fader.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector3(0,0,0);
            fader.CrossFadeAlpha(1f, 1f, true);
            Invoke("ActivateIt", 2f);
        }
    }
    void ActivateIt()
    {
        fader.CrossFadeAlpha(0, 1f, true);
        toActivate.SetActive(true);
        Invoke("DestroyFader", 2f);
    }
    void DestroyFader()
    {
        Destroy(this);
    }
}
