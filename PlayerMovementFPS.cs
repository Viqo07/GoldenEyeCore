using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementFPS : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Transform cameraTransform;
	public float mouseSensitivity = 2f;
	public float minPitch = -80f;
	public float maxPitch = 80f;

	private Rigidbody rb;
	private float pitch = 0f;
	private Vector2 inputMove;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
	}

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");
		inputMove = new Vector2(x, z).normalized;

		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

		transform.Rotate(Vector3.up * mouseX);

		pitch -= mouseY;
		pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

		if (cameraTransform != null)
			cameraTransform.localEulerAngles = new Vector3(pitch, 0, 0);
	}

	void FixedUpdate()
	{
		Vector3 move = transform.right * inputMove.x + transform.forward * inputMove.y;
		rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
	}
}