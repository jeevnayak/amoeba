using UnityEngine;
using System.Collections;

public class PredatorScript : MonoBehaviour {

	public float speed = 5f;

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

		movement = new Vector2(speed * direction.x, speed * direction.y);

		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Debug.Log (angle);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
	
	void FixedUpdate() {
		rigidbody2D.AddForce(movement);
	}
}
