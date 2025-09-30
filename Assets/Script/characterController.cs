using Unity.VisualScripting;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Animator animator;
    public float speed = 3.0f;
    public float jumpHeight = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isWalkingBack", false);
        animator.SetBool("isCrouch", false);
        animator.SetBool("isJump", false);
        animator.SetBool("isPunch", false);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            animator.SetBool("isWalkingBack", true);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jumpHeight * speed * Time.deltaTime);
            animator.SetBool("isJump", true);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            animator.SetBool("isCrouch", true);
        }
        else if (Input.GetMouseButton(0))
        {
            animator.SetBool("isPunch", true);
        }
    }
}
