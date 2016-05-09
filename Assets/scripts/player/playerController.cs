using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed = 10.0f;
	public GameObject bullet;

	public ParticleSystem explosion;

	void Update() {


		if (gameObject.tag == "Player") {
			//player movement
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical"); 
			transform.position = transform.position + new Vector3 (horizontal, vertical, 0) * (speed * Time.deltaTime);
		} else {
			return;
		}


	}


	//runs particle effect when killed
	void OnTriggerEnter () {
		Instantiate (explosion, this.transform.position,Quaternion.identity);
		Destroy (gameObject);
	}

}
