using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
	public Text ScoreText;
	public Text HealthText;
	public Slider SpeedSlider;
	public Dropdown AAMenu;
	public GameObject PausePanel;
	public GameObject HUDPanel;

	void Start() {
		HUDPanel.SetActive(true);
		PausePanel.SetActive(false);
		SpeedSlider.value = Global.Speed;
	}
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score: "+Global.Score;
		HealthText.text = "Health: "+Global.Health;
		Global.Speed = SpeedSlider.value;
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
		if(Input.GetKeyDown(KeyCode.Escape)) {
			HUDPanel.SetActive(!HUDPanel.activeInHierarchy);
			PausePanel.SetActive(!PausePanel.activeInHierarchy);
			if(Time.timeScale == 1F) {
				Time.timeScale = 0F;
			}
			else if(Time.timeScale == 0F) {
				Time.timeScale = 1F;
			}
		}
	}
}
