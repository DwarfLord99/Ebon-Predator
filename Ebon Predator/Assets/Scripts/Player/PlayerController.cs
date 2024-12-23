using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamage
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

    public float Health { get; set; }
    public int Defense { get; set; }

    void Start()
    {
        Health = playerHealth;
        Defense = 5;
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
            animator.SetBool("isMoving", false);
            animator.SetFloat("moveSpeed", 0);
        }

        //Player controls
        Vector2 movementVector = context.ReadValue<Vector2>();

        horizontalInput = movementVector.x;
        verticalInput = movementVector.y;

        if (context.performed)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("moveSpeed", verticalInput);
        }
    }

    public void TakeDamage(float damage)
    {
        // Apply defense to damage
        float totalDamage = damage - Defense;

        // If damage would drop below 0 due to defense, set to 0
        if(totalDamage < 0)
        {
            totalDamage = 0;
        }

        // Decrease health
        Health -= totalDamage;

        // Prevent health from going into negatives if damage dealt exceeds health
        if(totalDamage > Health)
        {
            Health = 0;
        }

        if(Health <= 0)
        {
            // If health hits 0, player dies
            Die();
        }
    }

    public void Die()
    {
        // play death animation
        Destroy(gameObject);
    }

    public void RestoreHealth()
    {
        // recover health when healed
    }

    public void DamageTest()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(10);
        }
    }
}
