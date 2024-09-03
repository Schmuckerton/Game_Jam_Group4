using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement: MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 4f;
    public float runSpeed = 9f;
    public float jumpPower = 4f;
    public float gravity = 10f;
    public float lookSpeed = 9f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float slideHeight = 1f;
    public float slideSpeed = 15f;
    public float slideDuration = 1f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    private bool canMove = true;
    private bool isSliding = false;
    private float slideTime = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.C) && canMove && isRunning && characterController.isGrounded && !isSliding)
        {
            isSliding = true;
            slideTime = slideDuration;
            characterController.height = slideHeight;
            moveDirection += forward * slideSpeed;
        }

        if (isSliding)
        {
            slideTime -= Time.deltaTime;
            if (slideTime <= 0)
            {
                isSliding = false;
                characterController.height = defaultHeight;
            }
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}