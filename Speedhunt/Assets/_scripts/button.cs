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
    [SerializeField] Text objectiveObject;
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
    void OnDisable()
    {
        if(iconClone != null)
            iconClone.gameObject.SetActive(false);
    }
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
            Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
            if(objectiveObject)
            {
                objectiveObject.gameObject.SetActive(true);
                objectiveObject.color = new Color(1, 1, 1, 0 + 1*(distance/100f));
                objectiveObject.text = "OBJECTIVE " + Mathf.RoundToInt(distance) + "M";
                objectiveObject.transform.position = namePose;
            }
            iconClone.transform.position = namePose;
            if (distance < 10f)
            {
                iconClone.gameObject.SetActive(true);
                iconClone.color = new Color(1, 1, 1, 1 - 1*(distance/opaqueDistance));
            }
            else if(distance > 10f)
            {
                iconClone.gameObject.SetActive(false);
            }
        }
        else
        {
            iconClone.gameObject.SetActive(false);
            if(objectiveObject)
            {
                objectiveObject.gameObject.SetActive(false);
            }
        }
    }
    void OnMouseEnter()
    {
        Debug.Log(Vector3.Distance(this.transform.position, Camera.main.transform.position));
        if(!Cursor.visible && Vector3.Distance(this.transform.position, Camera.main.transform.position) < 3f)
        {
            iconClone.sprite = iconTexture;
            iconText.gameObject.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        iconClone.sprite = defaultIcon;
        iconText.gameObject.SetActive(false);
    }
    void OnMouseDown()
    {
        if(!Cursor.visible && Vector3.Distance(this.transform.position, Camera.main.transform.position) < 3f)
        {
            activateIt.SetActive(false);
            activateIt.SetActive(true);
        }
    }
}
