using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFollow : MonoBehaviour
{
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed;

    public void SetWaypoints(List<Transform> waypoints)
    {
        this.waypoints = waypoints;
        currentWaypointIndex = 0;
        speed = Random.Range(1, 5);
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (waypoints != null && waypoints.Count > 0)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

            if (transform.position == targetWaypoint.position)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = 0;
                }

                if (currentWaypointIndex < waypoints.Count)
                {
                    Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
                    if (direction != Vector3.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                        transform.rotation = targetRotation;
                    }
                }
            }
        }
    }
}
