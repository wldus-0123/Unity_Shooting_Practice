using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController playerController;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    private Vector3 moveDir;
    private float ySpeed;

	private void Update()
	{
        Move();
        Jump();
	}

	private void Move()
    {
        playerController.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
		playerController.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
	}
	private void Jump()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;
		if (playerController.isGrounded)
		{
			ySpeed = 0;
		}
		playerController.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
    }

    private void OnJump(InputValue value) 
    {
        if(playerController.isGrounded)
        {
            ySpeed = jumpSpeed;
        }
    }
}
