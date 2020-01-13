using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setPlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerObject;
    Image fader = null;
    [SerializeField] string animationName = "";
    [SerializeField] bool Fade = false;
    void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        if(animationName == "" && Fade)
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
                fader.color = new Color(0, 0, 0, 1f);
                fader.CrossFadeAlpha(0f, 0.01f, true);
                RectTransform rect = fader.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(0, 0);
                rect.anchorMax = new Vector2(1, 1);
                rect.pivot = new Vector2(0.5f, 0.5f);
                rect.anchoredPosition = new Vector3(0,0,0);
            }
            fader.CrossFadeAlpha(1f, 1f, true);
            Invoke("SetPlayerPos", 2f);
        }
        else
        {
            SetPlayerPos();
        }
    }
    // Update is called once per frame
    void SetPlayerPos()
    {
        if(Fade == true)
        {
            fader.CrossFadeAlpha(0f, 1f, true);
            Invoke("DestroyFader", 2f);
        }
        if(animationName != "")
        {
            playerObject.GetComponent<Animator>().Play(animationName, -1);
        }
        else if(playerObject.tag == "Player")
        {
            playerObject.GetComponent<FirstPersonAIO>().originalRotation = this.transform.rotation.eulerAngles;
            playerObject.GetComponent<FirstPersonAIO>().targetAngles = Vector3.zero;
        }
        playerObject.transform.position = this.transform.position;
        playerObject.transform.rotation = this.transform.rotation;
    }
    void DestroyFader()
    {
        Destroy(fader.transform.parent.gameObject);
    }
}
