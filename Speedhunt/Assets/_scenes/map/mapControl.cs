using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mapControl : MonoBehaviour {
	void OnMouseEnter()
	{
		this.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("showinfo", true);
	}
	void OnMouseExit()
	{
		this.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("showinfo", false);
	}
	void OnMouseOver()
	{
		if (Input.GetMouseButton(0))
        {
			this.GetComponent<nextScene>().enabled=true;
		}
	}
}
