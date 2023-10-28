using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 3.0f;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Input handling
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction based on camera's forward direction
        Vector3 forwardDirection = Camera.main.transform.forward;
        forwardDirection.y = 0.0f;
        forwardDirection.Normalize();

        Vector3 moveDirection = (forwardDirection * vertical + Camera.main.transform.right * horizontal).normalized;

        // Apply rotation based on input
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Apply movement to the CharacterController
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
