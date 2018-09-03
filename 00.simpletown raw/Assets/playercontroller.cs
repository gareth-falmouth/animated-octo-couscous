using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float movementForce = 1.0f;
    public float cameraScale = 1;

    bool trackMouse = true;

    void Start () {
		
	}
		
	void Update ()
    {
        var rigidBody = GetComponent<Rigidbody>();
        var camera = transform.Find("Main Camera");

        rigidBody.AddForce(camera.transform.forward * movementForce * Input.GetAxis("Vertical"), ForceMode.Impulse);
        rigidBody.AddForce(camera.transform.right * movementForce * Input.GetAxis("Horizontal"), ForceMode.Impulse);

        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            trackMouse = !trackMouse;
        }

        var rotation = camera.localEulerAngles;
          
        rotation.y += Input.GetAxis("Mouse X") * cameraScale;
        rotation.x -= Input.GetAxis("Mouse Y") * cameraScale;

        if ((rotation.x > 30) && (rotation.x < 180))
        {
            rotation.x = 30;
        }

        if ((rotation.x < 330) && (rotation.x > 180))
        {
            rotation.x = 330;
        }

        GameObject.Find("debugtext").GetComponent<debugText>().Text = rotation.ToString();

        if (trackMouse == true)
        {
            camera.localEulerAngles = rotation;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
