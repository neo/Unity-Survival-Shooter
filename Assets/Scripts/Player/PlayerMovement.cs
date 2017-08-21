using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float Speed = 6f;

	Vector3 Movement;
	Animator Animator;
	Rigidbody PlayerRigibody;
	int FloorMask;
	float CameraRayLength = 100f;

	void Awake() {
		FloorMask = LayerMask.GetMask ("Floor");
		Animator = GetComponent<Animator> ();
		PlayerRigibody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

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
