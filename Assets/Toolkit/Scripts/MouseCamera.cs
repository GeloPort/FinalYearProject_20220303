using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public float mouseSensitivity = 25f;
    float xRotation = 0f;
    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        //Disables the Cursor from showing during gameplay on the TestingArea Scene
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        /*defines both mouseX and mouseY represent the correspondent axis, multiplied by the a defined mouse sensitivity and Time.deltaTime, in order to make sure that the mouseSensitivity won't
        stronger if the framerate is higher*/
        float mouseX = Input.GetAxis("Mouse X") * (mouseSensitivity * 2) * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * 2) * Time.deltaTime;


        //defines the camera's rotation on the Y axis, and blocks it from surpassing the 90 degrees values while looking up and down
        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        //rotates the player's body when moving on the X axis
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
