using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour {

	public float speed = 20.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);

	}
}
