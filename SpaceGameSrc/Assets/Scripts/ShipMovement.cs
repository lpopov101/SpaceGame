using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	public float ShipSpeed = 25f;

	public float SpeedDamp = 5f;

	public float Speed1Multiplier = 0.5f;
	public float Speed2Multiplier = 1.0f;
	public float Speed3Multiplier = 2.0f;

	public float TurnSpeedH = 150f;
	public float TurnSpeedV = 120f;

	public float TurnDampH = 5f;
	public float TurnDampV = 5f;

	public float TurnMaxH = 50f;
	public float TurnMaxV = 30f;

	public float ReleaseMinH = 5f;
	public float ReleaseMinV = 5f;

	public float ReleaseDampH = 5f;
	public float ReleaseDampV = 5f;

	private float HAngle = 0;
	private float VAngle = 0;

	private float CurSpeed = 0;

	private int SpeedMode = 2;

	void Start() {
		CurSpeed = ShipSpeed;
	}

	// Update is called once per frame
	void Update () {

		//HAngle += Input.GetAxis("Horizontal") * Time.deltaTime * TurnSpeedH;
		//VAngle += -Input.GetAxis("Vertical") * Time.deltaTime * TurnSpeedV;

		if (Input.GetAxisRaw ("Horizontal") == 0) {
			HAngle = Mathf.Lerp (HAngle, ReleaseMinH, Time.deltaTime * ReleaseDampH);
		} 
		else {
			HAngle = Mathf.Lerp (HAngle, Input.GetAxis ("Horizontal") * TurnMaxH, Time.deltaTime * TurnDampH);  
		}

		if(Input.GetAxisRaw("Vertical") == 0) {
			VAngle = Mathf.Lerp(VAngle, ReleaseMinV, Time.deltaTime*ReleaseDampV);
		}
		else {
			VAngle = Mathf.Lerp (VAngle, -Input.GetAxis ("Vertical") * TurnMaxV, Time.deltaTime * TurnDampV);  
		}

		//HAngle = Mathf.Clamp(HAngle, -TurnMaxH, TurnMaxH);
		//VAngle = Mathf.Clamp(VAngle, -TurnMaxV, TurnMaxV);

		Debug.Log("HAngle: " + HAngle);
		Debug.Log("VAngle: " + VAngle);
		
		transform.localEulerAngles = new Vector3(0, HAngle, VAngle);
		transform.Rotate(270, 0, 0);

		if(Input.GetButtonDown("Speed Up")) {
			if(SpeedMode < 3)
				SpeedMode++;
		}
		else if(Input.GetButtonDown("Speed Down")) {
			if(SpeedMode > 1)
				SpeedMode--;
		}

		float SpeedMult = 0f;

		switch (SpeedMode) {
			case 1:
				SpeedMult = Speed1Multiplier;
				break;
			case 2:
				SpeedMult = Speed2Multiplier;
				break;
			case 3:
				SpeedMult = Speed3Multiplier;
				break;
		}

		CurSpeed = Mathf.Lerp (CurSpeed, ShipSpeed * SpeedMult, Time.deltaTime * SpeedDamp);

		transform.Translate(-CurSpeed * SpeedMult * Time.deltaTime, 0, 0);
	}

	public float GetSpeed() {
		return CurSpeed;
	}
	public string GetSpeedMode() {
		switch (SpeedMode) {
			case 1:
				return "Slow";
			case 2:
				return "Normal";
			case 3:
				return "Fast";
		}
		return "Invalid";
	}
}
