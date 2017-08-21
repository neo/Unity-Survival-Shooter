using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform Target;
	public float Damp = 5f;

	Vector3 offset;

	void Start() {
		offset = transform.position - Target.position;
	}

	void FixedUpdate() {
		Vector3 CameraTargetPosition = Target.position + offset;
		transform.position = Vector3.Lerp (transform.position, CameraTargetPosition, Damp * Time.deltaTime);
	}
}
