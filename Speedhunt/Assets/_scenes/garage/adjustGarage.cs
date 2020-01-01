using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustGarage : MonoBehaviour
{
    [SerializeField] Material garageMaterial;
    [SerializeField] Light directionalLight;
    [SerializeField] Animator jeff;
    [SerializeField] Animator michelle;
    [SerializeField] Renderer sceneCar;
    [SerializeField] GameObject[] cutscenes;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("story", 0) == 3)
        {
            cutscenes[0].SetActive(true);
            sceneCar.gameObject.SetActive(true);
        }
        else
        {
            cutscenes[1].SetActive(true);
            int playAnim = Random.Range(0, 4);
            string[] animationNames = new string[]
            {
                "Bartending",
                "Working On Device",
                "Laying",
                "talking",
                "arguing",
                "phone"
            };
            Vector3[] animationPos = new Vector3[]
            {
                new Vector3(6.35f, -0.763f, 1.844f),
                new Vector3(5.264f, -0.763f, -5.142f),
                new Vector3(8.018f, -0.684f, -2.9f),
                new Vector3(-0.962f, -0.738f, -2.553f),
                new Vector3(-0.742f, -0.738f, -1.304f),
                new Vector3(-1.96f, -0.74f, -3.2f)

            };
            Vector3[] animationRot = new Vector3[]
            {
                new Vector3(0f, 0f, 0f),
                new Vector3(0f, 190f, 0f),
                new Vector3(0f, 180f, 0f),
                new Vector3(0, 10f, 0f),
                new Vector3(0, 190f, 0f),
                new Vector3(0, -135f, 0f)
            };
            if(playAnim == 0 || playAnim == 2)
            {
                sceneCar.transform.parent.gameObject.SetActive(true);
                foreach(Material mat in sceneCar.materials)
                {
                    if(mat.name == "subaru_body (Instance)")
                    {
                        mat.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
                    }
                    else
                    {
                        mat.DisableKeyword("_EMISSION");
                    }
                }
            }
            jeff.Play(animationNames[playAnim]);
            jeff.transform.position = animationPos[playAnim];
            jeff.transform.rotation =  Quaternion.Euler(animationRot[playAnim].x, animationRot[playAnim].y, animationRot[playAnim].z);
            if(playAnim == 4)
            {
                playAnim = 3;
            }
            else if(playAnim == 3)
            {
                playAnim = 4;
            }
            else
            {
                playAnim = Random.Range(0, 3);
            }
            michelle.Play(animationNames[playAnim]);
            michelle.transform.position = animationPos[playAnim];
            michelle.transform.rotation = Quaternion.Euler(animationRot[playAnim].x, animationRot[playAnim].y, animationRot[playAnim].z);
        }
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
