using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public Transform target; // Objeto cuya rotación se seguirá
    [SerializeField] float threshold = 15.0f;
    float initialRotation;
  float rotationSpeed = 1.0f;
    private void Start()
    {
        initialRotation = transform.rotation.eulerAngles.y;
    }
    private void Update()
    {
        Quaternion targetRotation = target.rotation;
        float yRotation = targetRotation.eulerAngles.y;

        if (Mathf.Abs(yRotation - initialRotation) > threshold)
        {
            Quaternion newRotation = Quaternion.Euler(0f, yRotation, 0f); 
            Quaternion interpolatedRotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);  
            transform.rotation = Quaternion.Euler(0f, interpolatedRotation.eulerAngles.y, 0f);
            initialRotation = transform.rotation.eulerAngles.y;
        }

    
    }


}
