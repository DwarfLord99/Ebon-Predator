using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerComponents")]
    [SerializeField] CharacterController characterController;

    [Header("PlayerStats")]
    [SerializeField] float playerHealth;
    [SerializeField] float moveSpeed;

    private float movementX;
    private float movementY;

    private float playerMaxHealth;

    void Start()
    {
        playerMaxHealth = playerHealth;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0, movementY);
        characterController.Move(movement * moveSpeed * Time.deltaTime);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        //checks if player is grounded
        if (characterController.isGrounded)
        {
            
        }

        //Player controls
        Vector2 movementVector = context.ReadValue<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
