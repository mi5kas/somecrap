using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boardControl : MonoBehaviour
{
    [SerializeField] Image infoBoard;
    [SerializeField] Sprite[] faces;
    [SerializeField] GameObject endBoard;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("story") >= 7)
        {
            this.transform.GetChild(5).gameObject.SetActive(true);
            Button tempButton = this.transform.GetChild(5).GetComponent<Button>();
            var tempColors = tempButton.colors;
            if(PlayerPrefs.GetInt("blacklist1", 0) == 2)
            {
                tempColors.normalColor = new Color(0.7f, 0, 0, 0.5f);
                tempColors.pressedColor = new Color(0.7f, 0, 0f, 0.5f);
                tempColors.highlightedColor = new Color(0.7f, 0, 0, 1f);
            }
            else if(PlayerPrefs.GetInt("blacklist1", 0) == 3)
            {
                tempColors.normalColor = new Color(0, 0, 0.7f, 0.5f);
                tempColors.pressedColor = new Color(0, 0, 0.7f, 0.5f);
                tempColors.highlightedColor = new Color(0f, 0, 0.7f, 1f);
            }
            tempButton.colors = tempColors;
        }
    }
    public void ShowInfo(int whichInfo)
    {
        if(whichInfo == 0) //Andrew's info
        {
            infoBoard.sprite = faces[0];
            infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: Andrew Jenkins\nAGE: 28\nSTATUS: On the run\n\nINFORMATION: Some info here";
        }
        else if(whichInfo == 1)
        {
            infoBoard.sprite = faces[1];
            if(PlayerPrefs.GetInt("blacklist1Status", 0) == 1)
            {
                infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: Scott Merkill\nAGE: 54\nSTATUS: On the run\n\nINFORMATION: Scott learned to work on cars from his father and started his own workshop when he was 16. Later he found out that fixing cars is not that profitable and began upgrading cars for illegal street racers. Not so long after he became a participant himself. However, it didn't take long for him to get busted and be locked up for a few months in a cell. Afterwards he cut all the strings to the street races and continued his legal mechanic business until he received a call from Andrew Jenkins a few months back.";
            }
            else
            {
                infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: Scott Merkill\nAGE: 54\nSTATUS: Apprehended\n\nINFORMATION: Scott learned to work on cars from his father and started his own workshop when he was 16. Later he found out that fixing cars is not that profitable and began upgrading cars for illegal street racers. Not so long after he became a participant himself. However, it didn't take long for him to get busted and be locked up for a few months in a cell. Afterwards he cut all the strings to the street races and continued his legal mechanic business until he received a call from Andrew Jenkins a few months back.";
            }
        }
        else if(whichInfo == 2)
        {
            if(PlayerPrefs.GetInt("blacklist2Status", 0) == 0)
            {
                infoBoard.sprite = faces[2];
                infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: UNKNOWN\nAGE: UNKNOWN\nSTATUS: Undiscovered\n\nINFORMATION: Someone is responsible for the smuggling in Willnews city. Progress in the story to find out who.";
            }
            else
            {
                infoBoard.sprite = faces[3];
            }
        }
        else if(whichInfo == 3)
        {
            infoBoard.sprite = faces[4];
            if(PlayerPrefs.GetInt("blacklist3Status", 0) == 1)
            {
                infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: Vladimir Pulout\nAGE: 68\nSTATUS: On the run\n\nINFORMATION: Vladimir used to be a loyal army general until the government forced him to retire due to his old age. An ordinary life didn't bring him satisfaction so when he received a call from Andrew Jenkins Pulout didn't turn down the offer to become a weapons' source for the gang.";
            }
            else
            {
                infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: Vladimir Pulout\nAGE: 68\nSTATUS: Apprehended\n\nINFORMATION: Vladimir used to be a loyal army general until the government forced him to retire due to his old age. An ordinary life didn't bring him satisfaction so when he received a call from Andrew Jenkins Pulout didn't turn down the offer to become a weapons' source for the gang.";
            }
        } 
        else if(whichInfo == 4)
        {
            if(PlayerPrefs.GetInt("blacklist4Status", 0) == 0)
            {
                infoBoard.sprite = faces[5];
                infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: UNKNOWN\nAGE: UNKNOWN\nSTATUS: Undiscovered\n\nINFORMATION: Someone is responsible for the prostitution in Willnews city. Progress in the story to find out who.";
            }
            else
            {
                infoBoard.sprite = faces[6];
            }
        }
        else if(whichInfo == 5)
        {
            if(PlayerPrefs.GetInt("blacklist5Status", 0) == 0)
            {
                infoBoard.sprite = faces[7];
                infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: UNKNOWN\nAGE: UNKNOWN\nSTATUS: Undiscovered\n\nINFORMATION: Someone is responsible for the drug dealing in Willnews city. Progress in the story to find out who.";
            }
            else
            {
                infoBoard.sprite = faces[8];
            }
        }
        else if(whichInfo == 6)
        {
            if(PlayerPrefs.GetInt("blacklist6Status", 0) == 0)
            {
                infoBoard.sprite = faces[9];
                infoBoard.transform.GetChild(0).GetComponent<Text>().text = "NAME: UNKNOWN\nAGE: UNKNOWN\nSTATUS: Undiscovered\n\nINFORMATION: Someone is responsible for the street racing in Willnews city. Progress in the story to find out who.";
            }
            else
            {
                infoBoard.sprite = faces[10];
            }
        }
        infoBoard.gameObject.SetActive(true);
        infoBoard.CrossFadeAlpha(0f, 0.0001f, true);
        infoBoard.CrossFadeAlpha(1f, 1f, true);
        infoBoard.transform.GetChild(0).GetComponent<Text>().CrossFadeAlpha(0f, 0.0001f, true);
        infoBoard.transform.GetChild(0).GetComponent<Text>().CrossFadeAlpha(1f, 1f, true);
        for(int i=0; i<7; i++)
        {
            this.transform.GetChild(i).GetComponent<Button>().interactable=false;
        }
    }
    public void exitButton()
    {
        if(infoBoard.gameObject.activeSelf)
        {
            for(int i=0; i<7; i++)
            {
                this.transform.GetChild(i).GetComponent<Button>().interactable=true;
            }
            infoBoard.gameObject.SetActive(false);
        }
        else
        {
            endBoard.SetActive(false);
            endBoard.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
