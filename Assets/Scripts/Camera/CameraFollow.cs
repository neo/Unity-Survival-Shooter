using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float Damp = 5f;

	Transform Target;
	Vector3 offset;

	void Start() {
		Target = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - Target.position;
	}

	void FixedUpdate() {
		Vector3 CameraTargetPosition = Target.position + offset;
		transform.position = Vector3.Lerp (transform.position, CameraTargetPosition, Damp * Time.deltaTime);
	}
}
