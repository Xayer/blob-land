using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private string mouseXAxis = "Mouse X";
    private string mouseYAxis = "Mouse Y";

    public float mouseSensitivity = 100f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis(mouseXAxis) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYAxis) * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, 0, 20f);
        yRotation = Mathf.Clamp(yRotation, -30f, 30f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
