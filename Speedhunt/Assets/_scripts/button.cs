using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    [SerializeField] GameObject activateIt;
    [SerializeField] Font font;
    [SerializeField] string buttonText;
    [SerializeField] Sprite defaultButton;
    [SerializeField] Sprite hoverButton;
    Image buttonImage;
    void Start()
    {
        CreateButton();
    }
    void CreateButton()
    {
        GameObject canvas = new GameObject("button Canvas");
        canvas.AddComponent<RectTransform>();
        canvas.AddComponent<Canvas>();
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        GameObject childObj = new GameObject();
        GameObject childObj2 = new GameObject();

        //Make block to be parent of this gameobject
        canvas.transform.parent = this.transform;
        childObj.transform.parent = canvas.transform;
        childObj2.transform.parent = childObj.transform;
        childObj2.SetActive(false);
        childObj.name = "buttonSprite";
        childObj2.name = "buttonText";
        //Create TextMesh and modify its properties
        buttonImage = childObj.AddComponent<Image>();
        buttonImage.sprite = defaultButton;
        Text textMesh = childObj2.AddComponent<Text>();
        textMesh.fontSize = 20;
        textMesh.text = buttonText;
        textMesh.rectTransform.localPosition = new Vector3(0, -75f, 0);
        textMesh.rectTransform.sizeDelta = new Vector2(160f, 30f);
        textMesh.alignment = TextAnchor.MiddleCenter;
        textMesh.font = font;
    }
    void OnDisable()
    {
        if(buttonImage != null)
            buttonImage.gameObject.SetActive(false);
    }
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
            Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
            /*if(objectiveObject)
            {
                objectiveObject.gameObject.SetActive(true);
                objectiveObject.color = new Color(1, 1, 1, 0 + 1*(distance/100f));
                objectiveObject.text = "OBJECTIVE " + Mathf.RoundToInt(distance) + "M";
                objectiveObject.transform.position = namePose;
            }*/
            buttonImage.transform.position = namePose;
            if (distance < 10f)
            {
                buttonImage.gameObject.SetActive(true);
                buttonImage.color = new Color(1, 1, 1, 1 - 1*(distance/10f));
            }
            else if(distance > 10f)
            {
                buttonImage.gameObject.SetActive(false);
            }
        }
        else
        {
            buttonImage.gameObject.SetActive(false);
        }
    }
    void OnMouseEnter()
    {
        if(Cursor.lockState == CursorLockMode.Locked && Vector3.Distance(this.transform.position, Camera.main.transform.position) < 3f)
        {
            buttonImage.sprite = hoverButton;
            buttonImage.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        buttonImage.sprite = defaultButton;
        buttonImage.transform.GetChild(0).gameObject.SetActive(false);
    }
    void OnMouseDown()
    {
        if(Cursor.lockState == CursorLockMode.Locked && Vector3.Distance(this.transform.position, Camera.main.transform.position) < 3f)
        {
            activateIt.SetActive(false);
            activateIt.SetActive(true);
        }
    }
}
