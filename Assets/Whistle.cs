using UnityEngine;
using System.Collections;

public class Whistle : MonoBehaviour {
	// Settables
	private float radiusFull = 5f; // Blow me.
	private float maxDistanceFromPlayer = 9f;
	// References
	private Player player;
	// Properties
	private float distanceOut; // TODO: explain this
	private float distanceX; // These are my position relative to the player.
	private float distanceZ; // These are my position relative to the player.

	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();

		distanceX = 0;
		distanceZ = 0;
		distanceOut = 0;
	}
	
	void Update () {
		// Always be on the ground, yo
		MoveToGroundY();

		// Move around from input!
		MoveFromInput();
	}

	void MoveToGroundY() {
		RaycastHit groundHit;
		if (Physics.Raycast (player.transform.position, Vector3.down, out groundHit)) {
			Debug.Log (groundHit.transform.position.y);
			transform.localPosition = new Vector3(transform.localPosition.x, player.transform.position.y-groundHit.distance+0.01f, transform.localPosition.z);
		}
	}

	void MoveFromInput() {
//		float playerRotationY = player.transform.eulerAngles.y/180*Mathf.PI;
//		distanceOut += Input.GetAxis ("Vertical");
//		distanceOut = 10f;
//		
//		if (distanceOut >  maxDistanceFromPlayer) { distanceOut =  maxDistanceFromPlayer; }
//		if (distanceOut < -maxDistanceFromPlayer) { distanceOut = -maxDistanceFromPlayer; }
//
//	    // Change distanceX and distanceZ
//		distanceX = Mathf.Sin (playerRotationY)*distanceOut;
//		distanceZ = Mathf.Cos (playerRotationY)*distanceOut;
		
		// Rotate the input vector into camera space so up is camera's up and right is camera's right
		Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		directionVector = Camera.main.transform.rotation * directionVector;

		distanceX += directionVector.x;
		distanceZ += directionVector.z;

		float totalDistance = Mathf.Sqrt((distanceX*distanceX) + (distanceZ*distanceZ));
		if (totalDistance > maxDistanceFromPlayer) {
			float angleFromPlayer = Mathf.Atan2 (distanceZ,distanceX);
			distanceX = Mathf.Cos (angleFromPlayer) * maxDistanceFromPlayer;
			distanceZ = Mathf.Sin (angleFromPlayer) * maxDistanceFromPlayer;
		}

		// Go to position!
		transform.position = new Vector3(player.transform.position.x+distanceX, transform.position.y, player.transform.position.z+distanceZ);
	}
}




