using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeAnim : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento
    public List<Transform> waypoints = new List<Transform>(); // Lista de puntos a los que se moverá el objeto
    private int currentWaypointIndex = 0;

    void Start()
    {
        // Comenzar la animación
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        while (true)
        {
            // Verificar si hay al menos un waypoint
            if (waypoints.Count > 0)
            {
                // Obtener el waypoint actual
                Transform currentWaypoint = waypoints[currentWaypointIndex];

                // Mover hacia el waypoint actual
                while (Vector3.Distance(transform.position, currentWaypoint.position) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
                    yield return null;
                }

                // Cambiar al siguiente waypoint
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            }
            else
            {
                Debug.LogWarning("No hay waypoints configurados.");
            }

            yield return null;
        }
    }
}
