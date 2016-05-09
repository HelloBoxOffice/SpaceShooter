using UnityEngine;
using System.Collections;

public class spaceDustMove : MonoBehaviour {

	public float speed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position -= transform.up * (speed * Time.deltaTime);
	
	}
}
