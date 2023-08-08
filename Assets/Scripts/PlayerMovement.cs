using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 15f; // Maximum speed of the car
    public float acceleration = 4f; // Acceleration rate
    public float spacebarBrakeForce = 10f; // Brake force when using spacebar to slow down
    public float turnSpeed = 50f; // Turning speed

    private Rigidbody rb;
    private float currentSpeed = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Input handling
        float accelerationInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
        bool spacebarPressed = Input.GetKey(KeyCode.Space);

        // Check for acceleration input (W or S keys)
        if (accelerationInput > 0f)
        {
            // Accelerate
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, 0f, maxSpeed);
        }
        else if (accelerationInput < 0f || spacebarPressed) // Brake when pressing S or Spacebar
        {
            // Brake
            currentSpeed = Mathf.Clamp(currentSpeed - spacebarBrakeForce * Time.deltaTime, 0f, maxSpeed);
        }
        

        // Calculate the movement vector
        Vector3 movement = transform.forward * currentSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Check for turning input (A or D keys)
        if (currentSpeed > 0f)
        {
            float turnAngle = turnInput * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turnAngle, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}
