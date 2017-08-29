using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class GameManager : MonoBehaviour {

	public GameObject Game;
	public float scale;

	GameObject Clone;
	Vector3 position;
	Quaternion rotation = new Quaternion(0, 0, 0, 0);

	void Start () {
//		Clone = Instantiate (Game, transform);
		UnityARSessionNativeInterface.ARAnchorAddedEvent += AddAnchor;
		UnityARSessionNativeInterface.ARAnchorUpdatedEvent += AddAnchor;
		GameObject.Find ("CameraParent").GetComponent <ContentScaleManager> ().ContentScale *= scale;
	}

	public void AddAnchor(ARPlaneAnchor arPlaneAnchor) {
		if (!Clone) {
			position = UnityARMatrixOps.GetPosition (arPlaneAnchor.transform);
			Clone = Instantiate (Game, position * scale, rotation, transform);
		}
	}

	public void Restart () {
		Destroy (Clone);
		Clone = Instantiate (Game, position * scale, rotation, transform);
	}
}
