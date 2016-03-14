using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public float TurnSpeedH = 150f;
	public float TurnSpeedV = 120f;

	public float TurnMaxH = 50f;
	public float TurnMaxV = 30f;

	public float ReleaseMinH = 5f;
	public float ReleaseMinV = 5f;

	public float ReleaseDampH = 5f;
	public float ReleaseDampV = 5f;

	private float HAngle = 0;
	private float VAngle = 0;

	// Update is called once per frame
	void Update () {

		HAngle += Input.GetAxis("Horizontal") * Time.deltaTime * TurnSpeedH;
		VAngle += -Input.GetAxis("Vertical") * Time.deltaTime * TurnSpeedV;

		if(Input.GetAxisRaw("Horizontal") == 0) {
			HAngle = Mathf.Lerp(HAngle, ReleaseMinH, Time.deltaTime*ReleaseDampH);
		}
		if(Input.GetAxisRaw("Vertical") == 0) {
			VAngle = Mathf.Lerp(VAngle, ReleaseMinV, Time.deltaTime*ReleaseDampV);
		}

		HAngle = Mathf.Clamp(HAngle, -TurnMaxH, TurnMaxH);
		VAngle = Mathf.Clamp(VAngle, -TurnMaxV, TurnMaxV);

		Debug.Log("HAngle: " + HAngle);
		Debug.Log("VAngle: " + VAngle);
		
		transform.localEulerAngles = new Vector3(0, HAngle, VAngle);
		transform.Rotate(270, 0, 0);

		transform.Translate(-Global.Speed * Time.deltaTime, 0, 0);
	}
}
