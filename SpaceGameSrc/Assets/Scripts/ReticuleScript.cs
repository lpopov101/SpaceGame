using UnityEngine;
using System.Collections;

public class ReticuleScript : MonoBehaviour {
	public Transform Camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera);
		transform.Rotate (270, 0, 0);
	}
}
