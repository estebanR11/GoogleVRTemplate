using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CameraMouseMovement : MonoBehaviour
{
#if UNITY_EDITOR
    public float rotationSpeed = 5f;

    private float yaw = 0f;
    private float pitch = 0f;
    [SerializeField] Transform character;
    private void Update()
    {
        if (Application.isPlaying)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yaw += mouseX * rotationSpeed;
            pitch -= mouseY * rotationSpeed;

            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

            if (character != null)
            character.rotation = Quaternion.Euler(0f, yaw, 0f);
        }
    }
#endif
}
