using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour {
	// Settables
	private float distanceUp = 4f;
	private float distanceAway = 10f;
	private float positionEasing = 3f;
	// References
	[SerializeField]
	Transform myTarget;
	// Properties
	private Vector3 targetPosition; // where I aim to put myself (we ease into this position)

	void Start () {
		
	}
	
	void FixedUpdate () {
		// Move to a nice position!
		float angleToTarget = Mathf.Atan2 (transform.position.z-myTarget.position.z, transform.position.x-myTarget.position.x);
		targetPosition = myTarget.position + Vector3.up*distanceUp + new Vector3(Mathf.Cos (angleToTarget)* distanceAway, 0, Mathf.Sin (angleToTarget)* distanceAway);
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*positionEasing);
		// Look at my target!
		transform.LookAt (myTarget);
	}
}
