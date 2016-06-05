using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
    public float speed = 15;

	private Transform player;
	private Vector3 v;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		v = Vector3.Normalize (player.position - transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (v * Time.deltaTime * speed);
	}
}
