using UnityEngine;
using System.Collections;

public class PreyScript : MonoBehaviour {

	public float speed = 1f;
	
	private Vector2 movement;
	
	void Update() {
		GameObject playerObject = GameObject.Find("Player");

		if (playerObject != null) {
			Vector2 playerPos = playerObject.transform.position;
		
			Vector2 currentPos = transform.position;
			Vector2 direction = currentPos - playerPos;
		
			float normalizeFactor = Mathf.Sqrt ((direction.x * direction.x) + 
					(direction.y * direction.y));
		
			direction.x = direction.x / normalizeFactor;
			direction.y = direction.y / normalizeFactor;
		
			movement = new Vector2 (speed * direction.x, speed * direction.y);
		}
	}
	
	void FixedUpdate() {
		rigidbody2D.AddForce(movement);
	}
}
