using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

	public GameObject enemy;
	public float spawnDelay = 0.5f;
	public bool readyToSpawn = true;
	public GameObject player;

	// Use this for initialization
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");

		if (player != null) {
			float posx = Random.Range (3.0f, -3.0f);
			Vector3 pos = new Vector3 (posx, 5.5f, 0);


			if (readyToSpawn) {
				Instantiate (enemy, pos, Quaternion.identity);
				readyToSpawn = false;
				Invoke ("resetReady", spawnDelay);
				spawnDelay -= 0.01f;
			}
		} else {
			return;
		}
	}

	void resetReady () {
		readyToSpawn = true;
	}

}
