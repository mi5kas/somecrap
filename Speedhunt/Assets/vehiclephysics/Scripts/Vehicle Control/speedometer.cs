using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

namespace RVP
{
public class speedometer : MonoBehaviour {
	
	// Update is called once per frame
	VehicleParent vp;	
	[SerializeField] CinemachineVirtualCamera carCamera;
	private CinemachineBasicMultiChannelPerlin vcam;
    [SerializeField] Transform rpm;
    [SerializeField] Text speed;

	Motor engine;

	void Start() {
		vcam = carCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		vp = GetComponent<VehicleParent>();
		engine = GetComponentInChildren<Motor>();
	}
	void Update () {
        rpm.transform.eulerAngles =  new Vector3(0, 0, -4 - 140 * engine.targetPitch);
        speed.text = (vp.velMag * 2.23694f * 1.6f).ToString("0");
        vcam.m_FrequencyGain = (vp.velMag * 2.23694f * 1.6f)/100;
    }
}
}
