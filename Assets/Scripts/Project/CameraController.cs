////////////////////////////////////////////////////////////////////////////////////
// AR-Target-Indicator-Tool -- Léo Séry
// ####
// Simple script to move the camera in order to use the tool in the demo scene.
// Script by Léo Séry - 08/02/2023
// ####
////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera;
    public float speed = 5f;
    public float xSensitivity = 100f;
    public float ySensitivity = 100f;
    public float xRotation = 0f;
    public float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Camera == null)
            Camera = Camera.main;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        Camera.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Camera.transform.position += Camera.transform.forward * vertical * speed * Time.deltaTime;
        Camera.transform.position += Camera.transform.right * horizontal * speed * Time.deltaTime;
    }
}