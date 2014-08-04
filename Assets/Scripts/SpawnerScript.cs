using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	
	/// <summary>
	/// Enemy prefab to spawn
	/// </summary>
	public Transform spawnPrefab;
	
	/// <summary>
	/// Cooldown between spawns
	/// </summary>
	public float spawnRate = 1f;
	public float minCooldown = 0.5f;
	
	//--------------------------------
	// Cooldown
	//--------------------------------
	private float spawnCooldown;
	
	void Start() {
		spawnCooldown = Random.Range (0f, spawnRate);
	}
	
	// Update is called once per frame
	void Update() {
		if (spawnCooldown > 0) {
			spawnCooldown -= Time.deltaTime;
		}
		Spawn ();
	}
	
	//--------------------------------
	// Spawning from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new object
	/// </summary>
	private void Spawn() {
		if (CanSpawn) {
			spawnCooldown = Random.Range (0f, spawnRate);
			spawnCooldown = Mathf.Max(spawnCooldown, minCooldown);
			//Debug.Log(spawnRate);
			
			// Create a new object
			var spawnTransform = Instantiate(spawnPrefab) as Transform;
			
			// Assign position
			spawnTransform.position = transform.position;
			
			// Make the game get harder
			spawnRate -= 0.05f;
		}
	}
	
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanSpawn {
		get {
			return spawnCooldown <= 0f;
		}
	}
}