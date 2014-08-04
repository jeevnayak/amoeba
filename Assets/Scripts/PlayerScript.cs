using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float defaultSpeed = 5f;
	public float minSpeed = 1f;
	public int numPreyEaten = 0;
	private float startSize;

	private Vector2 movement;

	// Use this for initialization
	void Start () {
		//jumpCooldown = 0f;
		transform.parent.gameObject.GetComponent<GameOverScript> ().enabled = false;
		startSize = transform.localScale.x;
	}

	void Update() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		float speed = defaultSpeed - (defaultSpeed - minSpeed) * (numPreyEaten / (numPreyEaten + 10f));
		movement = new Vector2(speed * inputX, speed * inputY);
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

		// Collision with enemy
		PredatorScript enemy = collision.gameObject.GetComponent<PredatorScript>();
		if (enemy != null) {
			// Dead!
			Destroy(gameObject);
		}
	}

	void EatPrey(PreyScript prey) {
		numPreyEaten++;
		UpdateSize();
		Destroy(prey.gameObject);
	}

	void UpdateSize() {
		float scale = startSize + numPreyEaten * 0.1f;
		rigidbody2D.transform.localScale = new Vector3(scale, scale, 1);
	}

	void OnDestroy() {
		// Game Over.
				
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.GetComponent<GameOverScript> ().enabled = true;
	}

}
