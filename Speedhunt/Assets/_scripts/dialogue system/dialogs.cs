using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogs : MonoBehaviour
{
    [SerializeField] Font ubuntu;
    [SerializeField] Animator actor;
    [TextArea]
    [SerializeField] string[] dialogues;
    Text dialogueText = null;
    Text nameText = null;
    [SerializeField] GameObject afterDialogue;
    [SerializeField] bool nextDialogue = false;
    [SerializeField] bool LookAtCamera = false;
    Image fader;
    bool typing = false;
    int currentDialogue = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(dialogueText == null)
        {
            GameObject canvas = new GameObject("dialogue Canvas");
            canvas.AddComponent<RectTransform>();
            canvas.AddComponent<Canvas>();
            CanvasScaler scaler = canvas.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920f, 1080f);
            scaler.matchWidthOrHeight = 0.5f;
            canvas.AddComponent<GraphicRaycaster>();
            canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            GameObject nameObj = new GameObject("name Text");
            nameObj.transform.parent = canvas.transform;
            nameText = nameObj.AddComponent<Text>();
            RectTransform rect = nameObj.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0);
            rect.anchorMax = new Vector2(0.5f, 0);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = new Vector2(1440f, 80f);
            rect.anchoredPosition = new Vector3(0, 130f, 0);
            nameText.font = ubuntu;
            nameText.fontSize = 35;
            nameText.color = new Color32(45, 170, 210, 255);
            nameText.alignment = TextAnchor.MiddleCenter;
            nameObj.AddComponent<Outline>();
            GameObject textObj = new GameObject("dialogue Text");
            textObj.transform.parent = canvas.transform;
            dialogueText = textObj.AddComponent<Text>();
            rect = dialogueText.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0);
            rect.anchorMax = new Vector2(0.5f, 0);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = new Vector2(1440f, 80f);
            rect.anchoredPosition = new Vector3(0, 60f, 0);
            dialogueText.font = ubuntu;
            dialogueText.alignment = TextAnchor.MiddleCenter;
            dialogueText.fontSize = 30;
            Outline outline = textObj.AddComponent<Outline>();
            outline.effectDistance = new Vector2(2f, -2f);
            canvas.transform.SetParent(this.transform);
        }
        currentDialogue = 0;
        ShowDialogue(dialogues[0]);
        if(LookAtCamera)
            actor.GetComponentInChildren<eyeMovement>().LookAtCamera();

    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueText != null && Input.GetMouseButtonDown(0))
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
            Destroy(dialogueText.transform.parent.gameObject);
            if(!nextDialogue)
            {
                if(afterDialogue != null)
                {
                    GameObject canvas = new GameObject("fader Canvas");
                    canvas.AddComponent<RectTransform>();
                    canvas.AddComponent<Canvas>();
                    CanvasScaler scaler = canvas.AddComponent<CanvasScaler>();
                    scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                    scaler.referenceResolution = new Vector2(1920f, 1080f);
                    scaler.matchWidthOrHeight = 0.5f;
                    canvas.AddComponent<GraphicRaycaster>();
                    canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                    GameObject faderObj = new GameObject("fader");
                    canvas.transform.parent = this.transform;
                    faderObj.transform.parent = canvas.transform;
                    fader = faderObj.AddComponent<Image>();
                    fader.color = new Color(0, 0, 0, 1);
                    fader.rectTransform.anchoredPosition = new Vector3(0, 0, 0);
                    fader.CrossFadeAlpha(0f, 0.0001f, true);
                    RectTransform rect = fader.GetComponent<RectTransform>();
                    rect.anchorMin = new Vector2(0, 0);
                    rect.anchorMax = new Vector2(1, 1);
                    rect.pivot = new Vector2(0.5f, 0.5f);
                    fader.CrossFadeAlpha(1f, 1f, true);
                    Invoke("AfterDialogue", 2);
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
            else
            {
                AfterDialogue();
            }
        }
    }
    void AfterDialogue()
    {
        if(fader)
        {
            Invoke("DestroyFader", 2f);
            fader.CrossFadeAlpha(0, 1, true);
        }
        if(LookAtCamera)
            actor.GetComponentInChildren<eyeMovement>().ResetEyes();
        afterDialogue.SetActive(false);
        afterDialogue.SetActive(true);
        if(actor)
            actor.CrossFadeInFixedTime("empty", 1f, 1);
    }
    void DestroyFader()
    {
        Destroy(fader.transform.parent.gameObject);
        this.gameObject.SetActive(false);
    }
    void ShowDialogue(string dialogue)
    {
        string[] tempDialogues = dialogue.Split('@');
        nameText.text = tempDialogues[0].ToUpper();
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
            actor.CrossFadeInFixedTime("sad", 1f, 1);
        }
        else if(tempDialogues[1] != "none")
        {
            actor.CrossFadeInFixedTime("empty", 1f, 1);
        }
		StopAllCoroutines();
		StartCoroutine (TypeSentence (tempDialogues[2]));
    }
    IEnumerator TypeSentence(string sentence)
	{
        typing = true; 
        dialogueText.text = "";
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
