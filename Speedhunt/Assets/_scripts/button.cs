using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    [SerializeField] string buttonName;
    [SerializeField] GameObject activateIt;
    [SerializeField] Sprite iconTexture;
    [SerializeField] Image template;
    //[SerializeField] Transform player;
    [SerializeField] float opaqueDistance = 10;
    Image iconClone;
    Sprite defaultIcon;
    Text iconText;

    void Start()
    {
        iconClone = Instantiate(template.gameObject, Vector3.zero, Quaternion.identity, template.transform.parent).GetComponent<Image>();
        iconClone.gameObject.SetActive(true);
        defaultIcon = iconClone.sprite;
        iconText = iconClone.gameObject.transform.GetChild(0).GetComponent<Text>();
        iconText.text = buttonName;
    }
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
        Vector3 visTest = Camera.main.WorldToViewportPoint(this.transform.position);
        if ((visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0)
        {
            Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
            iconClone.transform.position = namePose;
            if (distance < 10f)
            {
                iconClone.color = new Color32(255, 255, 255, (byte)(255 - 255*(distance/opaqueDistance)));
                //icon.rectTransform.sizeDelta = new Vector2(70 / distance, 70 / distance);
                //icon.color = new Color32(255, 255, 255, 255);
                //icon.gameObject.SetActive(true);
            }
            else
                iconClone.color = new Color32(255, 255, 255, 0);
        }
        else
            iconClone.color = new Color32(255, 255, 255, 0);
    }
    void OnMouseEnter()
    {
        iconClone.sprite = iconTexture;
        iconText.gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        iconClone.sprite = defaultIcon;
        iconText.gameObject.SetActive(false);
    }
    void OnMouseOver()
    {
        Debug.Log("Turi veikt");
    }
    void OnMouseDown()
    {
        activateIt.SetActive(false);
        activateIt.SetActive(true);
    }
}
