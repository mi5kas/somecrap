using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class choices : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] string[] buttonTexts;
    [SerializeField] GameObject[] afterButton;
    Button[] tempButtons;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<buttonTexts.Length; i++)
        {
            tempButtons[i] = buttons.transform.GetChild(i).GetComponent<Button>();
            tempButtons[i].gameObject.SetActive(true);
            tempButtons[i].transform.GetComponent<Text>().text = buttonTexts[i];
            tempButtons[i].onClick.AddListener(() => ButtonClicked(i)); 
        }
    }
    void ButtonClicked(int whichButton)
    {
        afterButton[whichButton].SetActive(false);
        afterButton[whichButton].SetActive(true);
        foreach(Button tempButton in tempButtons)
        {
            tempButton.onClick.RemoveAllListeners();
            tempButton.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
}
