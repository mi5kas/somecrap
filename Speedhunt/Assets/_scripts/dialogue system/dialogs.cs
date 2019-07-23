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
    [SerializeField] Transform cameraObject;
    [SerializeField] GameObject afterDialogue;
    [SerializeField] bool nextDialogue = false;
    bool typing = false;
    int currentDialogue = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentDialogue = 0;
        ShowDialogue(dialogues[0]);
        if(cameraObject != null)
            StartCoroutine(LookAtIt(actor.transform.position));

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
                if(afterDialogue != null)
                {
                    fader.CrossFadeAlpha(1, 1, true);
                    Invoke("AfterDialogue", 2);
                }
                dialogueText.gameObject.SetActive(false);
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
        afterDialogue.SetActive(true);
        actor.CrossFadeInFixedTime("empty", 1f, 1);
        this.gameObject.SetActive(false);
    }
    void ShowDialogue(string dialogue)
    {
        string[] tempDialogues = dialogue.Split('@');
        dialogueText.text = "<color=#D8FFFB>" + tempDialogues[0].ToUpper() + ": </color>";
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
    IEnumerator LookAtIt(Vector3 target)
    {
        target.y+=1.4f;
        Vector3 targetDir = target - cameraObject.transform.position;
        float step = 3 * Time.deltaTime;
        while(cameraObject.transform.rotation.eulerAngles != targetDir)
        {
            Vector3 newDir = Vector3.RotateTowards(cameraObject.transform.forward, targetDir, step, 0.0f);
            cameraObject.transform.rotation = Quaternion.LookRotation(newDir);
            yield return null;
        }
    }
    IEnumerator TypeSentence(string sentence)
	{
        typing = true; 
		foreach (char letter in sentence.ToCharArray())
		{
            if(!typing)
            {
                dialogueText.text = sentence;
                break;
            }
			dialogueText.text += letter;
			yield return null;
		}
        typing = false;
	}
}
