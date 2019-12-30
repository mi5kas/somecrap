using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustGarage : MonoBehaviour
{
    [SerializeField] Material garageMaterial;
    [SerializeField] Light directionalLight;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("isNight", 0) == 0)
        {
            directionalLight.color = new Color(0.5f, 0.5f, 0.5f, 1);
            garageMaterial.SetColor("_EmissionColor", new Color(0.7f, 0.7f, 0.7f, 7f));
        }
        else
        {
            directionalLight.color = new Color(1f, 1f, 1f, 1);
            garageMaterial.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
        }
    }
}
