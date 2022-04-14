using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw  = 0.0f;
    private float pitch = 0.0f; 
    // Start is called before the first frame update

    void Start()
    {
        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, -360f, 360f);
        //the rotation range
        pitch = Mathf.Clamp(pitch, -30f, 30f);
        //the rotation range

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
