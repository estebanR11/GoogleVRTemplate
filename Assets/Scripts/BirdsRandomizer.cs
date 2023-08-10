using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsRandomizer : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed = 2f;
    public List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private Quaternion targetRotation;

    void Start()
    {
        if (waypoints.Count > 0)
            SetNextWaypoint();
    }

    void Update()
    {
        if (waypoints.Count == 0)
            return;

        Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;
        targetDirection.x = -90f;
        targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            SetNextWaypoint();
        }
    }

    void SetNextWaypoint()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Count);
    }

    void LateUpdate()
    {
        // You can add clamping code here if needed.
    }
}
