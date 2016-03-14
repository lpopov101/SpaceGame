using UnityEngine;
using System.Collections;

public class FollowShip : MonoBehaviour {
	public Transform Ship;
	public float distance;
	public float speeddistancecoeff;
	public float Ybound;
	public float Zbound;
	public Vector3 modifier;
	public bool lookAtShip;
	public bool YZclamp;
	
	// Update is called once per frame
	void Update () {
		float curdistance = distance;
		ShipMovement Movement = Ship.gameObject.GetComponent<ShipMovement> ();
		if (Movement) {
			curdistance = distance + Movement.GetSpeed () * speeddistancecoeff;
		}

		float zpos = transform.position.z;
		float ypos = transform.position.y;
		float zmax = Ship.position.z + Zbound;
		float zmin = Ship.position.z - Zbound;
		float ymax = Ship.position.y + Ybound;
		float ymin = Ship.position.y - Ybound;

		if(YZclamp)
			transform.position = new Vector3(Ship.position.x + curdistance, Mathf.Clamp(ypos, ymin, ymax), Mathf.Clamp(zpos, zmin, zmax));
		else
			transform.position = new Vector3(Ship.position.x + curdistance, ypos, zpos);
		if(lookAtShip)
			transform.LookAt (Ship);
		transform.Rotate(modifier);
	}
}
