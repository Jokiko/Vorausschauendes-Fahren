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
    
    private GameObject brakingSound;
    private GameObject crashSound;
    private GameObject engineSound;

    private GameObject roadBarrel;

    private float distance = 0.0f;
    public TextMeshProUGUI winText;

    public bool playerControlEnabled = true;
    private bool triggerReached = false;



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

        brakingSound = GameObject.Find("Braking");
        brakingSound.SetActive(false);
        crashSound = GameObject.Find("Crash");
        crashSound.SetActive(false);
        engineSound = GameObject.Find("Engine");
        engineSound.SetActive(false);

        roadBarrel = GameObject.Find("GSDRoadBarrel");
    }

    private void FixedUpdate()
    {
        if(playerControlEnabled && !spacebarPressed){
            // Input handling
            accelerationInput = Input.GetAxis("Vertical");
            turnInput = Input.GetAxis("Horizontal");
            if(Input.GetKey(KeyCode.Space)){
                spacebarPressed = true;
                engineSound.SetActive(false);
                brakingSound.SetActive(true);
            }

        }

        // Check for acceleration input (W or S keys)
        if (spacebarPressed || loseScreen.activeSelf) // Brake when pressing S or Spacebar
        {
            // Brake
            currentSpeed = Mathf.Clamp(currentSpeed - spacebarBrakeForce * Time.deltaTime, 0f, maxSpeed);
        }
        else if (accelerationInput > 0f)
        {
            // Accelerate
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, 0f, maxSpeed);
            engineSound.SetActive(true);
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
            if(triggerReached){
                if(roadBarrel != null){
                    Vector3 remainingDistanceVector = roadBarrel.transform.position - transform.position;
                    distance = Mathf.Round(remainingDistanceVector.magnitude * 100)/ 100;
                    winText.text = $"Das waren noch {distance}m bis zum Crash";
                }
                else{
                    winText.text = $"Das war knapp!";
                }
                winScreen.SetActive(true);
            }
            else{
                tooEarlyScreen.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {   
            loseScreen.SetActive(true);
            playerControlEnabled = false;
            engineSound.SetActive(false);
            crashSound.SetActive(true);
        } 
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Huch");
        triggerReached = true;
        roadBarrel = GameObject.Find("GSDRoadBarrel(Clone)");
    }

}
