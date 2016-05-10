using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int score;


	void OnGUI() {
		GUI.Label (new Rect (10, 10, 150, 100), "Score: " + score);


	}


}
