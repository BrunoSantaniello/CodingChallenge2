using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    // Movement Variables
    public float movementSpeed = 5.0f; // Speed of movement
    private float jumpForce = 10.0f;    // Force applied for jumping
    private Rigidbody playerRB;         // Reference to the Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of the GameObject
        playerRB = GetComponent<Rigidbody>();
    }

    // Custom method for moving the player
    private void MovePlayer(float horizontalInput, float verticalInput)
    {
   
        //Translate for X Axis using Time.deltaTime
        transform.Translate(horizontalInput * Time.deltaTime * movementSpeed, 0, 0);
        //Translate for Z Axis using Time.deltaTime
        transform.Translate(0, 0, verticalInput * Time.deltaTime * movementSpeed);
    }

    // Custom method for making the player jump
    private void Jump()
    {  
            // Apply an upward force to initiate the jump
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for horizontal and vertical movement
        float horiMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        // Call the custom MovePlayer method
        MovePlayer(horiMovement, verMovement);

        // Check for the Jump input and call the custom Jump method
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
}
