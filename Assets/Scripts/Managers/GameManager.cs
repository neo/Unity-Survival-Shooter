using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class GameManager : MonoBehaviour {

	public GameObject Game;

	GameObject Clone;
	Vector3 position;
	Quaternion rotation;

	void Start () {
//		Clone = Instantiate (Game, transform);
		UnityARSessionNativeInterface.ARAnchorAddedEvent += AddAnchor;
	}

	public void AddAnchor(ARPlaneAnchor arPlaneAnchor) {
		if (!Clone) {
			position = UnityARMatrixOps.GetPosition (arPlaneAnchor.transform);
			rotation = UnityARMatrixOps.GetRotation (arPlaneAnchor.transform);
			Clone = Instantiate (Game, position, rotation, transform);
		}
	}

	public void Restart () {
		Destroy (Clone);
		Clone = Instantiate (Game, position, rotation, transform);
	}
}
