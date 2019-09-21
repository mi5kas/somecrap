using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class callSystem : MonoBehaviour
{
    [SerializeField] Animator phone;
    [SerializeField] Texture photo;
    [SerializeField] string name;
    // Start is called before the first frame update
    void Start()
    {
        phone.CrossFadeInFixedTime("open", 1f);
        phone.transform.GetChild(0).GetComponent<Text>().text = name;
        phone.transform.GetChild(1).GetComponent<RawImage>().texture = photo;
    }
    void OnDisable()
    {
        phone.CrossFadeInFixedTime("close", 1f);
    }
    // Update is called once per frame
}
