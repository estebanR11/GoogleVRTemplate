using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CameraMouseMovement : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float maxVerticalAngle = 30f;
    public float minVerticalAngle = -15f;

    private float yaw = 0f;
    private float pitch = 0f;

    private void Update()
    {
        if (Application.isPlaying)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yaw += mouseX * rotationSpeed;
            pitch -= mouseY * rotationSpeed;

            pitch = Mathf.Clamp(pitch, minVerticalAngle, maxVerticalAngle);

            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }
    }

}
