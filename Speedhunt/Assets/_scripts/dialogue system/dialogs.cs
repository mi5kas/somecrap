using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogs : MonoBehaviour
{
    [SerializeField] Animator actor;
    [TextArea]
    [SerializeField] string[] dialogues;
    [SerializeField] Text dialogueText;
    [SerializeField] RawImage fader;
    [SerializeField] GameObject afterDialogue;
    [SerializeField] bool nextDialogue = false;
    bool typing = false;
    int currentDialogue = 0;
    Text wholeText;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentDialogue = 0;
        wholeText = dialogueText.transform.GetChild(0).GetComponent<Text>();
        ShowDialogue(dialogues[0]);

    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueText.gameObject.activeSelf && Input.GetMouseButtonDown(0))
		{
			if(typing)
			{
				typing=false;
			}
			else
			{
				NextDialogue();
			}
		}
    }
    void NextDialogue()
    {
        if(currentDialogue != dialogues.Length-1)
        {
            currentDialogue++;
            ShowDialogue(dialogues[currentDialogue]);
        }
        else
        {
            if(!nextDialogue)
            {
                dialogueText.gameObject.SetActive(false);
                if(afterDialogue != null)
                {
                    fader.CrossFadeAlpha(1, 1, true);
                    Invoke("AfterDialogue", 2);
                }
                else
                    this.gameObject.SetActive(false);
            }
            else
            {
                AfterDialogue();
            }
        }
    }
    void AfterDialogue()
    {
        fader.CrossFadeAlpha(0, 1, true);
        afterDialogue.SetActive(false);
        afterDialogue.SetActive(true);
        actor.CrossFadeInFixedTime("empty", 1f, 1);
        this.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
    }
    void ShowDialogue(string dialogue)
    {
        string[] tempDialogues = dialogue.Split('@');
        dialogueText.text = tempDialogues[0].ToUpper();
        dialogueText.gameObject.SetActive(true);
        if(tempDialogues[1] == "happy")
        {
            actor.CrossFadeInFixedTime("happy", 1f, 1);
        }
        else if(tempDialogues[1] == "angry")
        {
            actor.CrossFadeInFixedTime("angry", 1f, 1);
        }
        else if(tempDialogues[1] == "neutral")
        {
            actor.CrossFadeInFixedTime("neutral", 1f, 1);
        }
        else if(tempDialogues[1] == "sad")
        {
            actor.CrossFadeInFixedTime("scared", 1f, 1);
        }
		StopAllCoroutines();
		StartCoroutine (TypeSentence (tempDialogues[2]));
    }
    IEnumerator TypeSentence(string sentence)
	{
        typing = true; 
        wholeText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
            if(!typing)
            {
                wholeText.text = sentence;
                break;
            }
			wholeText.text += letter;
			yield return null;
		}
        typing = false;
	}
}
