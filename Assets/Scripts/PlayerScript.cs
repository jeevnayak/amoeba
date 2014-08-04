using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(5, 5);
	public int numPreyEaten = 0;

	private Vector2 movement;
	
	void Update() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(speed.x * inputX, speed.y * inputY);
	}
	
	void FixedUpdate() {
		rigidbody2D.AddForce(movement);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		// collision with prey
		PreyScript prey = collision.gameObject.GetComponent<PreyScript>();
		if (prey != null) {
			EatPrey(prey);
		}
	}

	void EatPrey(PreyScript prey) {
		numPreyEaten++;
		UpdateSize();
		Destroy(prey.gameObject);
	}

	void UpdateSize() {
		float scale = 2f + numPreyEaten * 0.1f;
		rigidbody2D.transform.localScale = new Vector3(scale, scale, 1);
	}
}
