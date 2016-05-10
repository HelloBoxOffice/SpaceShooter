﻿using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour {

	public float speed = 20.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (gameObject.layer == 11) {
			transform.position = transform.position + new Vector3 (0, -speed * Time.deltaTime, 0);
		} else {
			transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);
		}

	}

	void OnTriggerEnter () {
		Destroy (gameObject);
	}
}
