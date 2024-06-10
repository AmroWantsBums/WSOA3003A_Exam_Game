using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float JumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    private bool canMove = true;


    private CharacterController _characterController;
    public Animator Player1Animator;
    public GunController gunController;

    public void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {


        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("MouseVertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("MouseHorizontal") : 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) && !gunController.IsShooting)
        {
            Player1Animator.SetBool("IsRunning", true);
        }
        else
        {
            Player1Animator.SetBool("IsRunning", false);
        }
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping

        /*if (Input.GetButton("Jump") && canMove && _characterController.isGrounded)
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
        }*/
        #endregion

        #region Handles Rotation
        _characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Math.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion

    }
}