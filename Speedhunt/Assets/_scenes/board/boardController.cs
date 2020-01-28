using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boardController : MonoBehaviour
{
    [SerializeField] GameObject[] cutscenes;
    [SerializeField] Text fugitiveInfo;
    [SerializeField] Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        int storyVar = PlayerPrefs.GetInt("story", 0);
        if(storyVar == 0)
        {
            cutscenes[0].SetActive(true);
        }
        else if(storyVar == 7)
        {
            cutscenes[1].SetActive(true);
            if(PlayerPrefs.GetInt("blacklist1Status", 0) == 0)
            {
                statusText.text = "ESCAPED";
                statusText.color = new Color(1, 0.2f, 0.2f, 1);
                fugitiveInfo.text = "NAME: Scott Merkill\nAGE: 54\nSTATUS: On the run\n\nINFORMATION: Scott learned to work on cars from his father and started his own workshop when he was 16. Later he found out that fixing cars is not that profitable and began smuggling cars, tobacco and illegal meds to the country. However, it didn't take long for him to get busted and be locked up for a few years in a cell. Afterwards he cut all the strings to the smuggling and continued his legal mechanic business until he received a call from Andrew Jenkins a few months back.";
            }
            else
            {
                statusText.text = "ARRESTED";
                statusText.color = new Color(0, 0, 0.77f, 1);
                fugitiveInfo.text = "NAME: Scott Merkill\nAGE: 54\nSTATUS: Apprehended\n\nINFORMATION: Scott learned to work on cars from his father and started his own workshop when he was 16. Later he found out that fixing cars is not that profitable and began smuggling cars, tobacco and illegal meds to the country. However, it didn't take long for him to get busted and be locked up for a few years in a cell. Afterwards he cut all the strings to the smuggling and continued his legal mechanic business until he received a call from Andrew Jenkins a few months back.";
            }
        }
    }

    // Update is called once per fram
}
