using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed = 10.0f;
	public float enemySpeed = 10.0f;

	public GameObject bullet;
	public GameObject enemyBullet;
	public float fireDelay = 0.5f;
	public bool readyToFire = true;

	public ParticleSystem explosion;

	public GameObject player;

	public GameObject world;
	public GameController script;

	public float posrand;
	public GameObject clone;

	void Start () {
		if (gameObject.tag != "Player") {
			player = GameObject.FindGameObjectWithTag ("Player");
			posrand = Random.Range (2f, -2f);

			world = GameObject.Find("$gameController");
			script = world.GetComponent<GameController> ();

		}
	}


	void Update() {

		//Checks if gameObject is Player
		if (gameObject.tag == "Player") {
			//player movement
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical"); 
			transform.position = transform.position + new Vector3 (horizontal, vertical, 0) * (speed * Time.deltaTime);
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -2.5f, 2.5f), Mathf.Clamp (transform.position.y, -4.5f, 4.5f), transform.position.z);
			//player shooting
			if (Input.GetButton("Fire1") && readyToFire) {
				Invoke("Shoot", 0.0f);
			}
		} else {
			if (readyToFire && transform.position.y <= 4.5) {
				Invoke ("Shoot", 0.0f);
			}
			if (player != null) {
				float playerx = (player.transform.position.x - transform.position.x) - posrand;

				transform.position = transform.position + new Vector3 (playerx, -1, 0) * (enemySpeed * Time.deltaTime);
				transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -2.5f, 2.5f), transform.position.y, transform.position.z);
			}
		}


	}


	//runs particle effect when killed
	void OnTriggerEnter () {
		if (gameObject.tag != "Player") {
			script.score += 10;
		}
		Instantiate (explosion, this.transform.position,Quaternion.identity);
		Destroy (gameObject);
	}



	void Shoot () {
		if (gameObject.tag == "Player") {
			Instantiate (bullet, gameObject.transform.position, Quaternion.identity);
		} else {
			clone = Instantiate (enemyBullet, gameObject.transform.position, Quaternion.identity) as GameObject;
			clone.layer = 11;
		}
		readyToFire = false;
		Invoke("resetFire", fireDelay);
	}

	void resetFire () {
		readyToFire = true;
	}

}
