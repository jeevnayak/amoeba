using UnityEngine;
using System.Collections;

public class RandomMoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);

	public Vector2 direction;
	private Vector2 movement;
	
	void Update() {
		direction = new Vector2(2f * (Random.value - 0.5f), 2f * (Random.value - 0.5f));
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}
	
	void FixedUpdate() {
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}
}
