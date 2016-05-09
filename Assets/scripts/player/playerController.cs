using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed = 10.0f;

	public GameObject bullet;
	public float fireDelay = 0.5f;
	public bool readyToFire = true;

	public ParticleSystem explosion;


	void Update() {

		//Checks if gameObject is Player
		if (gameObject.tag == "Player") {
			//player movement
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical"); 
			transform.position = transform.position + new Vector3 (horizontal, vertical, 0) * (speed * Time.deltaTime);
			//player shooting
			if (Input.GetButton("Fire1") && readyToFire) {
				Instantiate(bullet,gameObject.transform.position,Quaternion.identity);
				readyToFire = false;
				Invoke("resetFire", fireDelay);
			}
		} else {
			return;
		}


	}


	//runs particle effect when killed
	void OnTriggerEnter () {
		Instantiate (explosion, this.transform.position,Quaternion.identity);
		Destroy (gameObject);
	}

	void resetFire () {
		readyToFire = true;
	}

}
