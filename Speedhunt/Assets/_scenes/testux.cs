using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;

public class testux : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pushcar = false;
    public float thrust;
    void Start()
    {
        Profiler.BeginSample("My Sample");
        for(int i=0; i<1000; i++)
        {
            GameObject childObj = new GameObject();
            GameObject childObj2 = new GameObject();

        //Make block to be parent of this gameobject
            childObj.transform.parent = this.transform.parent;
            childObj2.transform.parent = childObj.transform;
            childObj2.SetActive(false);
            childObj.name = "buttonSprite";
            childObj2.name = "buttonText";
            //Create TextMesh and modify its properties
            Image buttonImage = childObj.AddComponent<Image>();
            Text textMesh = childObj2.AddComponent<Text>();
            textMesh.fontSize = 20;
            textMesh.text = "lol";
            textMesh.rectTransform.localPosition = new Vector3(0, -75f, 0);
            textMesh.rectTransform.sizeDelta = new Vector2(160f, 30f);
            textMesh.alignment = TextAnchor.MiddleCenter;
            Destroy(childObj);
            Destroy(childObj2);
        }
        Profiler.EndSample();
    }
    // Update is called once per frame
}
