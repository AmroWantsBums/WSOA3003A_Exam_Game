using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float JumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed;
    public float lookXLimit = 45f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    private bool canMove = true;

    private CharacterController _characterController;
    public Player2GunController gunController;
    public Animator Player2Animator;
    public bool IsRunning = false;
    public AudioSource RunSource;

    public void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        if (IsRunning)
        {
            if (RunSource.isPlaying)
            {

            }
            else
            {
                RunSource.Play();
            }
        }
        else
        {
            RunSource.Stop();
        }
        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Shift to run (assuming the left joystick click is for running)
        bool isRunning = Input.GetButton("Fire3"); // Default is usually the left joystick button
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("ControllerVertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("ControllerHorizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if (Input.GetAxis("ControllerVertical") != 0 && !gunController.IsShooting)
        {
            Player2Animator.SetBool("IsRunning", true);
            IsRunning = true;
        }
        else
        {
            Player2Animator.SetBool("IsRunning", false);
            IsRunning = false;
        }
        #endregion

        /*#region Handles Jumping
        if (Input.GetButton("Jump") && canMove && _characterController.isGrounded)
        {
            moveDirection.y = JumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!_characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        #endregion*/

        #region Handles Rotation
        _characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            // Right joystick for camera movement
            rotationX += -Input.GetAxis("ControllerLookVertical") * -lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("ControllerLookHorizontal") * lookSpeed, 0);
        }
        #endregion
    }
}
