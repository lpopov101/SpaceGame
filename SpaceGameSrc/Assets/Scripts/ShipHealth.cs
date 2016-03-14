using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Global.Health <= 0) {
			Global.endGame ();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Projectile") {
			Global.Health -= 20;
			Destroy (other.gameObject);
		}
	}
}
