using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Transform FirePoint;
	public GameObject Projectile;
	public float distance = 80;
	public float ROF = 1;

	private Transform Player;
	private float lasttimefired;

	void Start() {
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		lasttimefired = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float timesincefired = Time.time - lasttimefired;
		if (Vector3.Distance (Player.position, transform.position) <= distance && timesincefired >= ROF && Player.position.x > transform.position.x) {
			Instantiate (Projectile, FirePoint.position, FirePoint.rotation);
			lasttimefired = Time.time;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Rocket") {
			Global.Score += 10;
			Destroy (gameObject);
		}
	}
}
