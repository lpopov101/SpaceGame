using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 4);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-60 * Time.deltaTime, 0, 0);
	}
}
