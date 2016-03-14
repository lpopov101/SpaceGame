using UnityEngine;
using System.Collections;

public class FollowReticule : MonoBehaviour {
	public Transform Reticule;
	public float distance;
	public float Ybound;
	public float Zbound;
	public Vector3 modifier;
	public bool lookAtReticule;
	public bool YZclamp;
	
	// Update is called once per frame
	void Update () {
		float zpos = transform.position.z;
		float ypos = transform.position.y;
		float zmax = Reticule.position.z + Zbound;
		float zmin = Reticule.position.z - Zbound;
		float ymax = Reticule.position.y + Ybound;
		float ymin = Reticule.position.y - Ybound;

		if(YZclamp)
			transform.position = new Vector3(Reticule.position.x + distance, Mathf.Clamp(ypos, ymin, ymax), Mathf.Clamp(zpos, zmin, zmax));
		else
			transform.position = new Vector3(Reticule.position.x + distance, ypos, zpos);
		if(lookAtReticule)
			transform.LookAt (Reticule);
		transform.Rotate(modifier);
	}
}
