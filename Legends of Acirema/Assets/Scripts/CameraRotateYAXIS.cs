using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float sensitivity = 10f;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var c = Camera.main.transform;
        c.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        c.Rotate(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }
}

