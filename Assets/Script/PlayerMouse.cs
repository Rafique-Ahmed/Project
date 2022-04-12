using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{   
    //Mouse Movement script 
    public float speedH = 2.0f;

    private float yaw  = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");

        yaw = Mathf.Clamp(yaw, -360f, 360f);

        transform.eulerAngles = new Vector3(0,yaw, 0.0f);
    }
}
