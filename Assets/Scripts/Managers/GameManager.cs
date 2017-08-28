using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject Game;

	GameObject Clone;

	void Start () {
		Clone = Instantiate (Game, transform);
	}

	public void Restart () {
		Destroy (Clone);
		Clone = Instantiate (Game, transform);
	}
}
