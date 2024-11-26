using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerComponents")]
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator animator;
    [SerializeField] Transform cameraTransform;

    [Header("PlayerStats")]
    [SerializeField] float playerHealth;
    [SerializeField] float moveSpeed;

    private float horizontalInput;
    private float verticalInput;

    private float playerMaxHealth;

    void Start()
    {
        playerMaxHealth = playerHealth;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement;
        characterController.Move(movement * moveSpeed * Time.deltaTime);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        //checks if player is grounded
        if (characterController.isGrounded)
        {
            
        }

        if (context.canceled)
        {
            //animator.SetBool("isWalking", false);
            animator.SetFloat("speed", 0);
        }

        //Player controls
        Vector2 movementVector = context.ReadValue<Vector2>();

        horizontalInput = movementVector.x;
        verticalInput = movementVector.y;

        if (context.performed)
        {
            //animator.SetBool("isWalking", true);
            animator.SetFloat("speed", verticalInput);
        }
    }
}
