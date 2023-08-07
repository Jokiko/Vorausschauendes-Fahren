using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Sensitivity of the camera rotation
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;

    // Minimum and maximum vertical angles to restrict camera movement
    public float minimumY = -90f;
    public float maximumY = 90f;

    // Current rotation of the camera
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        // Lock and hide the cursor to prevent it from leaving the game window
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        // Calculate the new rotation values based on mouse movement
        rotationX += mouseX;
        rotationY -= mouseY;

        // Clamp the vertical rotation to avoid flipping the camera
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}