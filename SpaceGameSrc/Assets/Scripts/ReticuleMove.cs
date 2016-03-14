using UnityEngine;
using System.Collections;

public class ReticuleMove : MonoBehaviour {
	public Transform Camera;
	public Transform Ship;
	public float SpeedX;
	public float SpeedY;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Camera);
		transform.Rotate (270, 0, 0);
		Vector3 ship2cam = transform.position - Camera.position;
		transform.Translate ((Vector3.Normalize(ship2cam) * Global.Speed * Time.deltaTime) + new Vector3(0, Input.GetAxis ("Vertical") * SpeedY * Time.deltaTime, Input.GetAxis ("Horizontal") * SpeedX * Time.deltaTime), Space.World);
	}
}
