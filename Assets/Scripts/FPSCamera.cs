using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCamera : MonoBehaviour
{
	[SerializeField] Transform cameraRoot;
	[SerializeField] float mouseSeneitivity;

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
		xRotation -= -Input.GetAxis("Mouse Y") * mouseSeneitivity * Time.deltaTime;
		xRotation = Mathf.Clamp(xRotation, -80f, 80f);

		transform.Rotate(Vector3.up, -Input.GetAxis("Mouse X") * mouseSeneitivity * Time.deltaTime);
		cameraRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);
	}

}
