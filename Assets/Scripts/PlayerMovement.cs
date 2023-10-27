using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform cameraTransform; // Reference to the main camera's transform

    private float _turnSmoothVelocity;
    public float _turnSmoothTime = 1f;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
            Vector3 moveDirection = forward * vertical;

            // Move the player
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            // Only rotate the player when there is horizontal input
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                Vector3 right = Vector3.Cross(Vector3.up, forward);
                moveDirection += right * horizontal;

                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            }
        }
    }
}