using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapManager : MonoBehaviour {

	// Use this for initialization
	public GameObject policeicon;
	public GameObject garageicon;
	public Text moneytext;
	public Text heattext;
	public Text reptext;
	public Texture daytex;
	public Texture nighttex;
	public GameObject[] races;
	public GameObject[] sidequests;
	public GameObject[] smses;
	void Start () {
		if(PlayerPrefs.GetInt("isNight", 0) == 1)
		{
		   PlayerPrefs.SetInt("isNight", 0);
		   races[0].SetActive(true);
		   races[1].SetActive(true);
           this.GetComponent<Renderer>().material.SetTexture("_MainTex", nighttex);
		   if(PlayerPrefs.GetInt("mainQuest", 0) == 3)
		   {
			   races[2].SetActive(true);
		   }
		}
		else
		{
			PlayerPrefs.GetInt("isNight", 1);
			policeicon.SetActive(true);
			garageicon.SetActive(true);
			this.GetComponent<Renderer>().material.SetTexture("_MainTex", daytex);
		}
		/*          SHOWING SMS'ES                      */
		if(PlayerPrefs.GetInt("story", 0) == 0)//Showing Nicole's SMS
		{
			smses[0].SetActive(true);
			PlayerPrefs.SetInt("story", 1);
		}
		else if(PlayerPrefs.GetInt("story", 0) == 1)//Showing Bob's SMS
		{
			smses[1].SetActive(true);
			PlayerPrefs.SetInt("story", 2);
		}
		moneytext.text = "MONEY: $" + PlayerPrefs.GetInt("money", 0);
		reptext.text = "REPUTATION: " + PlayerPrefs.GetInt("reputation", 0);
		if(PlayerPrefs.GetInt("heat", 0) >= 10)
		{
			heattext.text = "HEAT: <color=#E80022>DANGEROUS</color>";
		}
		else if(PlayerPrefs.GetInt("heat", 0) >= 5)
		{
			heattext.text = "HEAT: SUSPICIOUS";
		}
		else
		{
			heattext.text = "HEAT: <color=#1082DA>INDIFFERENT</color>";
		}
	}
}
