using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
	public Camera cam;

	public float mouseSensitivity = 5.0f;

	public bool InvertHorizontal = true;
	public bool InvertVertical = false;

	float verticalRotation = 0;
	float horizontalRotation = 0;

	public float upDownRange = 60.0f;

	void Start() {
		if (!cam) {
			cam = Camera.main;
		}
	}

	void FixedUpdate () 
	{
		horizontalRotation -= Input.GetAxis("Mouse X") * mouseSensitivity * (InvertHorizontal ? -1 : 1);

		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * (InvertVertical ? -1 : 1);
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		cam.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
	}
}