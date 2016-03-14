using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {
	public GameObject rocket;
	public Transform firePoint1;
	public Transform firePoint2;

	private bool whichOne;
	// Use this for initialization
	void Start () {
		whichOne = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			if(whichOne)
				Instantiate (rocket, firePoint1.position, firePoint1.rotation);
			else
				Instantiate (rocket, firePoint2.position, firePoint2.rotation);
			whichOne = !whichOne;
		}
	}
}
