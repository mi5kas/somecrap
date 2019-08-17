using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class choices : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] string[] buttonTexts;
    [SerializeField] GameObject[] afterButton;
    Button[] tempButtons = new Button[3];
    // Start is called before the first frame update
    void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        for(int i=0; i<buttonTexts.Length; i++)
        {
            int tempNumber = i;
            tempButtons[i] = buttons.transform.GetChild(i).GetComponent<Button>();
            tempButtons[i].gameObject.SetActive(true);
            tempButtons[i].transform.GetComponent<Text>().text = buttonTexts[i];
            tempButtons[i].onClick.AddListener(() => ButtonClicked(tempNumber)); 
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void ButtonClicked(int whichButton)
    {
        Debug.Log(whichButton);
        afterButton[whichButton].SetActive(false);
        afterButton[whichButton].SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        foreach(Button tempButton in tempButtons)
        {
            tempButton.onClick.RemoveAllListeners();
            tempButton.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
}
