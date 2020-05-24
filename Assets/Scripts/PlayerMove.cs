// using UnityEngine;
// using System.Collections;

// // This script moves the character controller forward
// // and sideways based on the arrow keys.
// // It also jumps when pressing space.
// // Make sure to attach a character controller to the same game object.
// // It is recommended that you make only one call to Move or SimpleMove per frame.

// public class PlayerMove : MonoBehaviour
// {
//     CharacterController characterController;
//     // Gravity gravity;

//     public bool isGrounded = false;
//     public float speed = 6.0f;
//     public float jumpSpeed = 8.0f;
//     private float gravity = 20.0f;

//     private Vector3 moveDirection = Vector3.zero;

//     void Awake()
//     {
//         characterController = GetComponent<CharacterController>();
//         // gravity = GetComponent<Gravity>();
//         characterController.enabled = true;
//     }

//     void FixedUpdate()
//     {

//             // We are grounded, so recalculate
//             // move direction directly from axes

//             moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
//             moveDirection *= speed;

//             // if (Input.GetButton("Jump"))
//             // {
//             //     Vector3 jumpVector = new Vector3(gravity.force)
//             //     gravity.rb.AddForce();
//             // }
        

//         // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
//         // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
//         // as an acceleration (ms^-2)
//         // moveDirection.y -= Time.deltaTime;

//         // Move the controller
//         characterController.Move(moveDirection * Time.deltaTime);
//     }
// }