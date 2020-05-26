/* https://www.youtube.com/watch?v=WsE4BgZMjK8 */
using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GravityBody))]
public class FirstPersonController : MonoBehaviour {
	
	// public vars
	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
	public float walkSpeed = 6;
	public float jumpForce = 220;
	public LayerMask groundedMask;
	
	// System vars
	public bool isGrounded;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	float verticalLookRotation;
	Transform cameraTransform;
	Rigidbody rigidbody;


	void Awake() {
		// Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cameraTransform = Camera.main.transform;
		rigidbody = GetComponent<Rigidbody> ();
	}

	void Update()
    {
        // Look rotation:
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation,-60,60);
        cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;

        // Calculate movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        HandleJump();
    }

    private void HandleJump()
    {
        GetAndSetIsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rigidbody.AddForce(transform.up * jumpForce);

            // Debug.Log("Space key was pressed.");
            // Debug.Log("isGrounded:");
            // Debug.Log(isGrounded);
        }

        // if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     Debug.Log("Space key was released.");
        //     Debug.Log("isGrounded:");
        //     Debug.Log(isGrounded);
        // }
    }

    private void GetAndSetIsGrounded()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f, groundedMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void FixedUpdate() {

		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + localMove);
	}
}
