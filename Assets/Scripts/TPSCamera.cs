using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPSCamera : MonoBehaviour
{
	[SerializeField] Transform cameraRoot;
	[SerializeField] float mouseSensitivity;

	private Vector2 inputDir;
	private float xRotation;

	private void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void OnDisable()
	{
		Cursor.lockState = CursorLockMode.None;
	}

	private void LateUpdate()
	{
		//xRotation -= -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		xRotation -= -inputDir.y * mouseSensitivity * Time.deltaTime;
		xRotation = Mathf.Clamp(xRotation, -80f, 80f);

		//transform.Rotate(Vector3.up, -Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
		transform.Rotate(Vector3.up, -inputDir.x * mouseSensitivity * Time.deltaTime);
		cameraRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);
	}

	private void OnLook(InputValue value)
	{
		inputDir = value.Get<Vector2>();
	}

}
