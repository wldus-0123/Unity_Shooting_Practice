using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController playerController;
    [SerializeField] Animator animator;

    [SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float jumpSpeed;

    private Vector3 moveDir;
    private float ySpeed;
    private bool isRun;

	private void Update()
	{
        Move();
        Jump();
	}

	private void Move()
    {
        if(isRun)
        {
			playerController.Move(transform.right * moveDir.x * runSpeed * Time.deltaTime);
			playerController.Move(transform.forward * moveDir.z * runSpeed * Time.deltaTime);
            animator.SetFloat("XSpeed", moveDir.x * runSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("YSpeed", moveDir.z * runSpeed, 0.1f, Time.deltaTime);
		}
        else
        {
			playerController.Move(transform.right * moveDir.x * walkSpeed * Time.deltaTime);
			playerController.Move(transform.forward * moveDir.z * walkSpeed * Time.deltaTime);
			animator.SetFloat("XSpeed", moveDir.x * walkSpeed, 0.1f, Time.deltaTime);
			animator.SetFloat("YSpeed", moveDir.z * walkSpeed, 0.1f, Time.deltaTime);
		}

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

    private void OnRun(InputValue value)
    {
        if (value.isPressed)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }
    }

    private void OnFire(InputValue value)
    {
        animator.SetTrigger("Fire");
    }

    private void OnReload(InputValue value)
    {
        animator.SetTrigger("Reload");
    }
}
