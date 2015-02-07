using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour {
	// Settables
	private float distanceUp = 3f;
	private float distanceAway = 5f;
	private float positionEasing = 2f;
	// References
	[SerializeField]
	Transform myTarget;
	// Properties
	private Vector3 targetPosition; // where I aim to put myself (we ease into this position)

	void Start () {
		
	}
	
	void Update () {
		// Move to a nice position behind my target!
		targetPosition = myTarget.position + Vector3.up*distanceUp - myTarget.forward*distanceAway;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*positionEasing);
		// Look at my target!
		transform.LookAt (myTarget);
	}
}
