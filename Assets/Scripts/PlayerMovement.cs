using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 15f; // Maximum speed of the car
    public float acceleration = 4f; // Acceleration rate
    public float spacebarBrakeForce = 10f; // Brake force when using spacebar to slow down
    public float turnSpeed = 50f; // Turning speed

    private float accelerationInput;
    private float turnInput;
    private bool spacebarPressed;

    private Rigidbody rb;
    private float currentSpeed = 0f;

    private GameObject loseScreen;
    private GameObject winScreen;
    private GameObject tooEarlyScreen;

    private float distance = 0.0f;
    public TextMeshProUGUI winText;

    public bool playerControEnabled = true;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        loseScreen = GameObject.Find("LoseCanvas");
        loseScreen.SetActive(false);
        winScreen = GameObject.Find("WinCanvas");
        winScreen.SetActive(false);
        winText.text = $"Das waren noch {distance}m bis zum Crash";
        tooEarlyScreen = GameObject.Find("TooEarlyCanvas");
        tooEarlyScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(playerControEnabled && !spacebarPressed){
            // Input handling
            accelerationInput = Input.GetAxis("Vertical");
            turnInput = Input.GetAxis("Horizontal");
            if(Input.GetKey(KeyCode.Space)){
                spacebarPressed = true;
            }

        }

        // Check for acceleration input (W or S keys)
        if (accelerationInput < 0f || spacebarPressed) // Brake when pressing S or Spacebar
        {
            // Brake
            currentSpeed = Mathf.Clamp(currentSpeed - spacebarBrakeForce * Time.deltaTime, 0f, maxSpeed);
        }
        else if (accelerationInput > 0f)
        {
            // Accelerate
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, 0f, maxSpeed);
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

        //check for win condition
        if (currentSpeed <= 0f && spacebarPressed){
            tooEarlyScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision){
        
        Debug.Log("Kollision!");
        if (collision.gameObject.CompareTag("Obstacle"))
        {   
            loseScreen.SetActive(true);
            playerControEnabled = false;
        } 
        
    }

        void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Trigger!");
    }

}
