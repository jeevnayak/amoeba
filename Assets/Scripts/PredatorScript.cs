using UnityEngine;
using System.Collections;

public class PredatorScript : MonoBehaviour {

	public Vector2 speed = new Vector2(5, 5);

	private Vector2 movement;
	
	void Update() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		GameObject playerObject = GameObject.Find("Player");
		Vector2 playerPos = playerObject.transform.position;

		Vector2 currentPos = transform.position;
		Vector2 direction = playerPos - currentPos;

		float normalizeFactor = Mathf.Sqrt ((direction.x * direction.x) + 
		                                    (direction.y * direction.y));

		direction.x = direction.x / normalizeFactor;
		direction.y = direction.y / normalizeFactor;

		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}
	
	void FixedUpdate() {
		rigidbody2D.AddForce(movement);
	}
}
