﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;

public class UIScript : MonoBehaviour {
	public Text ScoreText;
	public Text HealthText;
	public Text SpeedText;
	public Dropdown AAMenu;
	public GameObject PausePanel;
	public GameObject HUDPanel;
	public MonoBehaviour CameraBlur;

	void Start() {
		HUDPanel.SetActive(true);
		PausePanel.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
        {
            VRSettings.enabled = !VRSettings.enabled;
            Debug.Log("Changed VRSettings.enabled to:" + VRSettings.enabled);
        }
        ScoreText.text = "Score: "+Global.Score;
		HealthText.text = "Health: "+Global.Health;
		ShipMovement Movement = GameObject.FindGameObjectWithTag ("Player").GetComponent<ShipMovement> ();
		if (Movement) {
			SpeedText.text = "Speed: " + Movement.GetSpeedMode ();
		}
		switch(AAMenu.value) {
			case 0:
				QualitySettings.antiAliasing = 0;
				break;
			case 1:
				QualitySettings.antiAliasing = 2;
				break;
			case 2:
				QualitySettings.antiAliasing = 4;
				break;
			case 3:
				QualitySettings.antiAliasing = 8;
				break;
		}
		if(Input.GetButtonDown("Pause")) {
			HUDPanel.SetActive(!HUDPanel.activeInHierarchy);
			PausePanel.SetActive(!PausePanel.activeInHierarchy);
			if(Time.timeScale == 1F) {
				CameraBlur.enabled = true;
				Time.timeScale = 0F;
			}
			else if(Time.timeScale == 0F) {
				CameraBlur.enabled = false;
				Time.timeScale = 1F;
			}
		}
	}
}
