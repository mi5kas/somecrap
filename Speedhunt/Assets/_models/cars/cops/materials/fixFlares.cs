using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixFlares : MonoBehaviour {

	// Use this for initialization
	private LensFlare comp;
	private float defaultBrightness;
	void Start () {
		InvokeRepeating("Flareupdate", 0, 0.2f);
		comp = this.GetComponent<LensFlare>();
		defaultBrightness = comp.brightness;
	}
	
	// Update is called once per frame
	void Flareupdate () {
		comp.brightness = (float) (defaultBrightness-0.02*Vector3.Distance(transform.position, Camera.main.transform.position));
	}
}