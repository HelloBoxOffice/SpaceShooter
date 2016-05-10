using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed = 10.0f;
	public float enemySpeed = 10.0f;

	public GameObject bullet;
	public float fireDelay = 0.5f;
	public bool readyToFire = true;

	public ParticleSystem explosion;

	public GameObject player;

	public GameObject world;
	public GameController script;

	public float posrand;

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
			//player shooting
			if (Input.GetButton("Fire1") && readyToFire) {
				Instantiate(bullet,gameObject.transform.position,Quaternion.identity);
				readyToFire = false;
				Invoke("resetFire", fireDelay);
			}
		} else {
			if (player != null) {
				float playerx = (player.transform.position.x - transform.position.x) - posrand;
				transform.position = transform.position + new Vector3 (playerx, -1, 0) * (enemySpeed * Time.deltaTime);
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

	void resetFire () {
		readyToFire = true;
	}

}
