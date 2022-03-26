using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 5;
    public float sprintSpeed = 10;

    Vector3 velocity;
    public float gravity = -9.1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;


    // Update is called once per frame
    void Update()
    {
        MoveDirection();
        GroundCheck();
        Jump();
        SprintMove();
    }


    // Defines the input for movement of both X and Y axis and applies them to enable the player to move at a set speed, regardless of framerate
    public void MoveDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movementSpeed * Time.deltaTime);
    }


    /* Uses an EmptyGameObject that is a child of the player's character, to verify if the player is grounded or not. isGrounded uses the position of the EmptyGameObject,
    the distance to the floor and a check on any items that belong to the "Ground" layer to verify if the player is grounded or not*/
    public void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }


    /* Verifies if the player has pressed the "Space" key while on the ground in order to jump. The jump changes the velocity of the player on the Y axis to the Square Root of
    the jumpHeight multipled by -2f and the weight of the gravity */ 
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Changes the player's movement speed to equal its sprint speed if the Left Shift key is held
    public void SprintMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }
        else
        {
            movementSpeed = 5;
        }
    }
}
