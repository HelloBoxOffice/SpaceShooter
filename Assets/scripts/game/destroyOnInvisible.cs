using UnityEngine;
using System.Collections;

public class destroyOnInvisible : MonoBehaviour {

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
