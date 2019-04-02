﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is so you can move the camera during play using right click (1)
public class CameraOrbit_OLD : MonoBehaviour
{
    //Distance the camera is from world zero
    public float distance = 10f;
    // X and Y rotation speed
    public float xSpeed = 120f, ySpeed = 120f;
    // X and Y rotation limits
    public float yMin = 15f, yMax = 80f;
    // Store current x and y rotation
    private float x, y;


    // Update is called once per frame
    void LateUpdate()
    {
        // If the right mouse button is pressed
        if (Input.GetMouseButton(1))
        {
            // Hide the cursor
            Cursor.visible = false;
            // Get input X and Y offsets
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            // Offset rotation with mouse X and Y
            x += mouseX * xSpeed * Time.deltaTime;
            y -= mouseY * ySpeed * Time.deltaTime;
            // Clamp the Y between min and max limits
            y = Mathf.Clamp(y, yMin, yMax);
        }
        // Update transform
        transform.rotation = Quaternion.Euler(y, x, 0);
        transform.position = -transform.forward * distance;
    }
}
