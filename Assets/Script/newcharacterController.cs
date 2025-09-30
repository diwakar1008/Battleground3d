using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class newPlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 3.0f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;  // for gravity

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Reset animator states every frame
        animator.SetBool("isWalking", false);
        animator.SetBool("isWalkingBack", false);
        animator.SetBool("isCrouch", false);
        animator.SetBool("isJump", false);

        // --- Movement ---
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            move += Vector3.forward;
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += Vector3.back;
            animator.SetBool("isWalkingBack", true);
        }

        // Move character using CharacterController
        controller.Move(move * speed * Time.deltaTime);

        // --- Jump ---
        if (controller.isGrounded)
        {
            velocity.y = -2f; // keep grounded

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                animator.SetBool("isJump", true);
            }
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // --- Crouch ---
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("isCrouch", true);
        }
    }
}

