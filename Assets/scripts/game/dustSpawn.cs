using UnityEngine;
using System.Collections;

public class dustSpawn : MonoBehaviour {

	public GameObject dust;
	public float spawnDelay = 0.5f;
	public bool readyToSpawn = true;

	// Use this for initialization
	void Update () {

		float posx = Random.Range (3.0f, -3.0f);
		Vector3 pos = new Vector3 (posx, 5.5f, 0);


		if (readyToSpawn) {
			Instantiate(dust, pos, Quaternion.identity);
			readyToSpawn = false;
			Invoke("resetReady", spawnDelay);
		}
	}
	
	void resetReady () {
		readyToSpawn = true;
	}

}
