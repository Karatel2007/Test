using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private GameObject playerBody;
    [SerializeField] private float sensitivity;

    private float rotationY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rotationY = transform.eulerAngles.x;
    }

    private void Update()
    {

        
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            rotationY -= mouseY;

            playerBody.transform.Rotate(Vector3.up * mouseX);

            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

            //transform.eulerAngles = new Vector3(rotationY, 0, 0);
        
    }
}
