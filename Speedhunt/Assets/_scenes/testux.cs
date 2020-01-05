using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;
using UnityEngine.Networking;

public class testux : MonoBehaviour
{
    // Start is called before the first frame update
    Texture2D texture;
    [SerializeField] Text text;
    Vector2 screenSize;
    Vector2 positionRatio;
    void Start()
    {
        texture = this.GetComponent<RawImage>().mainTexture as Texture2D;
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            text.color = texture.GetPixel(Mathf.RoundToInt(Input.mousePosition.x-960f-500f), Mathf.RoundToInt(Input.mousePosition.y-540-500));
        }
    }
    // Update is called once per frame
}
