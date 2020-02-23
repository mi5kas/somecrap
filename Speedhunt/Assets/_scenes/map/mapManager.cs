using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mapManager : MonoBehaviour {

	// Use this for initialization
	public GameObject policeicon;
	public GameObject garageicon;
	public Text moneytext;
	public Text heattext;
	public Text reptext;
	[SerializeField] Text dayText;
	public Texture daytex;
	public Texture nighttex;
	public GameObject[] races;
	public GameObject[] sidequests;
	public GameObject[] smses;
	[SerializeField] Transform labels;
	void Start () {
		if(PlayerPrefs.GetInt("story", 0) >= 2)
		{
			garageicon.SetActive(true);
		}
		if(PlayerPrefs.GetInt("isNight", 0) == 1)
		{
		   dayText.text = "NIGHT";
		   PlayerPrefs.SetInt("isNight", 0);
		   races[0].SetActive(true);
		   races[1].SetActive(true);
           this.GetComponent<Renderer>().material.SetTexture("_MainTex", nighttex);
		   if(PlayerPrefs.GetInt("story") > 0)
		   {
			   labels.GetChild(0).gameObject.SetActive(true);
			   labels.GetChild(0).GetChild(0).gameObject.SetActive(true);
			   labels.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = PlayerPrefs.GetInt("northtownRep", 0) + "/1000";
			   if(PlayerPrefs.GetInt("northtownRep", 0) == 4000)
			   {
				   labels.GetChild(0).GetComponent<TextMeshPro>().color = new Color32(45, 170, 210, 255);
				   labels.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().color = new Color32(45, 170, 210, 255);
			   }
		   }
		   if(PlayerPrefs.GetInt("story", 0) == 5 && PlayerPrefs.GetInt("reputation", 0) > 2000)
		   {
			   races[2].SetActive(true);
		   }
		   if(PlayerPrefs.GetInt("mainQuest", 0) == 3)
		   {
			   races[2].SetActive(true);
		   }
		}
		else
		{
			dayText.text = "DAY";
			PlayerPrefs.SetInt("isNight", 1);
			policeicon.SetActive(true);
			this.GetComponent<Renderer>().material.SetTexture("_MainTex", daytex);
		}
		/*          SHOWING SMS'ES                      */
		if(PlayerPrefs.GetInt("story", 0) == 1)//Showing Mia's SMS
		{
			smses[0].SetActive(true);
			PlayerPrefs.SetInt("story", 2);
		}
		else if(PlayerPrefs.GetInt("story", 0) == 2)//Showing Bob's SMS
		{
			smses[1].SetActive(true);
			PlayerPrefs.SetInt("story", 3);
		}
		else if(PlayerPrefs.GetInt("story", 0) == 4) //Showing Mia's SMS about extra work
		{
			smses[2].SetActive(true);
			PlayerPrefs.SetInt("story", 5);
		}
		else if(PlayerPrefs.GetInt("story", 0) == 4 && PlayerPrefs.GetInt("isNight") == 0)
		{
			smses[3].SetActive(true);
		}
		else if(PlayerPrefs.GetInt("story", 0) == 5 && PlayerPrefs.GetInt("reputation", 0) > 2000)
		{
			smses[4].SetActive(true);
			PlayerPrefs.SetInt("story", 6);
		}
		moneytext.text = "MONEY: $" + PlayerPrefs.GetInt("money", 0);
		reptext.text = "REPUTATION: " + PlayerPrefs.GetInt("reputation", 0);
		string starChar = new string(heattext.text[heattext.text.Length-1], PlayerPrefs.GetInt("heat", 0));
		if(PlayerPrefs.GetInt("heat", 0) == 5)
		{
			heattext.text = "HEAT: <color=#d64d61>" + starChar + "</color>";
		}
		else if(PlayerPrefs.GetInt("heat", 0) >= 3)
		{
			heattext.text = "HEAT: <color=#d6cf4d>" + starChar + "</color>";
		}
		else
		{
			heattext.text = "HEAT: " + starChar;
		}
	}
}
