using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class namePicker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] InputField inputField;
    [SerializeField] GameObject nextDialogue;
    public void SetName()
    {
        if(inputField.text.Length > 0)
        {
            PlayerPrefs.SetString("nickname", inputField.text);
            nextDialogue.SetActive(true);
            PlayerPrefs.SetInt("story", 5);
            gameObject.SetActive(false);
        }
    }
}
