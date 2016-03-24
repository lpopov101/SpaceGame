using UnityEngine;
using System.Collections;

public class FollowShip : MonoBehaviour {
	public Transform Ship;
	public float distance;
	public float speeddistancecoeff;
	public float Ybound;
	public float Zbound;
	public float Yoffset = 5f;
	public float Zoffset = 0f;
	public Vector3 modifier;
	public bool lookAtShip;
	public bool YZclamp;
	public float ZDamp = 5f;
	public float YDamp = 5f;
	public float ResetDamp = 5f;

	private float ypos;
	private float zpos;

	void Start () {
		ypos = transform.position.y;
		zpos = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float curdistance = distance;
		ShipMovement Movement = Ship.gameObject.GetComponent<ShipMovement> ();
		if (Movement) {
			curdistance = distance + Movement.GetSpeed () * speeddistancecoeff;
		}

		float zmax = Ship.position.z + Zbound + Zoffset;
		float zmin = Ship.position.z - Zbound + Zoffset;
		float ymax = Ship.position.y + Ybound + Yoffset;
		float ymin = Ship.position.y - Ybound + Yoffset;

		if(Input.GetAxisRaw("Vertical") > 0)
			ypos = Mathf.Lerp (ypos, ymax, YDamp * Time.deltaTime * Mathf.Abs(Input.GetAxis("Vertical")));
		else if(Input.GetAxisRaw("Vertical") < 0 * Mathf.Abs(Input.GetAxis("Vertical")))
			ypos = Mathf.Lerp (ypos, ymin, YDamp * Time.deltaTime);
		else
			ypos = Mathf.Lerp (ypos, Ship.position.y + Yoffset, ResetDamp * Time.deltaTime);

		if(Input.GetAxisRaw("Horizontal") > 0)
			zpos = Mathf.Lerp (zpos, zmax, ZDamp * Time.deltaTime * Mathf.Abs(Input.GetAxis("Horizontal")));
		else if(Input.GetAxisRaw("Horizontal") < 0)
			zpos = Mathf.Lerp (zpos, zmin, ZDamp * Time.deltaTime * Mathf.Abs(Input.GetAxis("Horizontal")));
		else
			zpos = Mathf.Lerp (zpos, Ship.position.z + Zoffset, ResetDamp * Time.deltaTime);


		if(YZclamp)
			transform.position = new Vector3(Ship.position.x + curdistance, ypos, zpos);
		else
			transform.position = new Vector3(Ship.position.x + curdistance, ypos, zpos);
		if(lookAtShip)
			transform.LookAt (Ship);
		transform.Rotate(modifier);
	}
}
