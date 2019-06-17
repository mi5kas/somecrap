using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeLights : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Texture[] lightTextures;
    bool whichLight = false;
    Material lightsMaterial;
    void Start()
    {
        InvokeRepeating("SwitchLights", 0.5f, 0.5f);
        foreach (Material material in GetComponent<Renderer>().materials)
        {
                        if (material.name == "lights (Instance)")
                        {
                            lightsMaterial = material;
                            break;
                        }
        }
    }

    void SwitchLights()
    {
        if(whichLight)
        {
            lightsMaterial.SetTexture("_EmissionMap", lightTextures[0]);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            lightsMaterial.SetTexture("_EmissionMap", lightTextures[1]);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
        }
        Debug.Log(Vector3.Distance(transform.position, Camera.main.transform.position));
        whichLight = !whichLight;
    }
    // Update is called once per fram
}
