using UnityEngine;
using CnControls;

public class PlayerMovement : MonoBehaviour
{
	public float Speed = 6f;
	public bool onScreenControls;

	Vector3 Movement;
	Animator Animator;
	Rigidbody PlayerRigibody;
	int FloorMask;
	float CameraRayLength = 100f;

	void Awake() {
		FloorMask = LayerMask.GetMask ("Floor");
		Animator = GetComponent<Animator> ();
		PlayerRigibody = GetComponent<Rigidbody> ();
		GameObject.FindGameObjectWithTag ("onScreenControls").SetActive (onScreenControls);
		GetComponentInChildren<PlayerShooting> ().autoShoot = onScreenControls;
	}

	void FixedUpdate() {
		float h = onScreenControls ? CnInputManager.GetAxisRaw ("Horizontal") : Input.GetAxisRaw ("Horizontal");
		float v = onScreenControls ? CnInputManager.GetAxisRaw ("Vertical") : Input.GetAxisRaw ("Vertical");

		Animate (h, v);
		Move (h, v);
		Turn ();
	}

	void Move(float h, float v) {
		Movement.Set (h, 0f, v);

		Movement = Movement.normalized * Speed * Time.deltaTime;

		PlayerRigibody.MovePosition (transform.position + Movement);
	}

	void Turn() {
		if (onScreenControls) {
			float x = CnInputManager.GetAxisRaw ("TurnX");
			float z = CnInputManager.GetAxisRaw ("TurnZ");

			if (x == 0f && z == 0f)
				return;

			Vector3 direction = new Vector3 (x, 0f, z);
			PlayerRigibody.MoveRotation (Quaternion.LookRotation (direction));
			return;
		}

		Ray CameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit FloorHit;

		if (Physics.Raycast (CameraRay, out FloorHit, CameraRayLength, FloorMask)) {
			Vector3 PlayerToMouse = FloorHit.point - transform.position;
			PlayerToMouse.y = 0f;

			Quaternion Rotation = Quaternion.LookRotation (PlayerToMouse);
			PlayerRigibody.MoveRotation (Rotation);
		}
	}

	void Animate(float h, float v) {
		bool walking = h != 0f || v != 0f;
		Animator.SetBool ("IsWalking", walking);
	}
}
