using UnityEngine;
using System.Collections;

public class destroyOnParticleEnd : MonoBehaviour {
	public ParticleSystem ps;

	void Start() {

		ps = gameObject.GetComponent<ParticleSystem>();
	}

	void Update() {

		if (ps) {
			if (!ps.IsAlive ()) {
				Destroy (gameObject);
			}
		}

	}

}
