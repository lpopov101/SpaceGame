using UnityEngine;
using System.Collections;

public class DynamicReticule : MonoBehaviour {
	public Transform Origin;

	public float MaxDistance = 30f;
	public float MinDistance = 10f;

	public float ReticuleDamp = 5f;

	private float CurDistance = 0f;

	private RaycastHit hit;

	void Start () {
		CurDistance = MinDistance;
	}
	
	// Update is called once per frame
	void Update () {
		float Distance = 0;
		if (Physics.Raycast (Origin.position, -Origin.right, out hit, MaxDistance)) {
			Distance = Mathf.Clamp (hit.distance, MinDistance, MaxDistance);
		} 
		else {
			Distance = MinDistance;
		}
		CurDistance = Mathf.Lerp (CurDistance, Distance, Time.deltaTime * ReticuleDamp);
		transform.localPosition = new Vector3 (-CurDistance, 0, 0);
	}
}
