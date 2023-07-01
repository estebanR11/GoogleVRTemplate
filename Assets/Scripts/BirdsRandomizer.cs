using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsRandomizer : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed = 2f;
    public float minX = -32f;
    public float maxX = 36f;
    public float minZ = 63f;
    public float maxZ = 125f;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        GenerateRandomPosition();
    }

    void Update()
    {
        Vector3 targetDirection = targetPosition - transform.position;
        targetDirection.y = 0f;
        targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            GenerateRandomPosition();
        }
    }

    void GenerateRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);
        transform.position = clampedPosition;
    }
}
