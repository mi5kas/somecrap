using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walkObjective : MonoBehaviour
{
    [SerializeField] GameObject toActivate;
    [SerializeField] RawImage fader;
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
        GameObject canvas = new GameObject("objective Canvas");
        canvas.AddComponent<RectTransform>();
        canvas.AddComponent<Canvas>();
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.transform.parent = this.transform;
        GameObject childObj = new GameObject();
        //Make block to be parent of this gameobject
        childObj.transform.parent = canvas.transform.parent;
        childObj.name = "objective Text";
        //Create TextMesh and modify its properties
        textMesh = childObj.AddComponent<Text>();
        textMesh.fontSize = 20;
        textMesh.rectTransform.localPosition = Vector3.zero;
        textMesh.rectTransform.sizeDelta = new Vector2(300f, 30f);
        textMesh.alignment = TextAnchor.MiddleCenter;
        textMesh.font = font;
    }
    void Update()
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
    void OnTriggerEnter(Collider other)
    {
        if(toActivate)
        {
            toActivate.SetActive(true);
            Destroy(this);
        }
    }
}
