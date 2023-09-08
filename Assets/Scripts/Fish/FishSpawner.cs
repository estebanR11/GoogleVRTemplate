using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> fishesPrefab;
    [SerializeField] List<Transform> waypoints;

    [SerializeField] private int maxFishCount = 50;

    void Start()
    {
        for (int i = 0; i < maxFishCount; i++)
        {
            Vector3 spawnPosition = waypoints[Random.Range(0, waypoints.Count)].position;
            GameObject fishPrefab = fishesPrefab[Random.Range(0, fishesPrefab.Count)];
            GameObject newFish = Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
            FishFollow fishFollow = newFish.GetComponent<FishFollow>();

            if (fishFollow != null)
            {
                List<Transform> randomWaypoints = new List<Transform>();
                List<Transform> shuffledWaypoints =waypoints;
                for (int j = 0; j < waypoints.Count; j++)
                {
                    int randomIndex = Random.Range(j, waypoints.Count);
                    randomWaypoints.Add(waypoints[randomIndex]);
                    shuffledWaypoints[randomIndex] = shuffledWaypoints[j];
                }

                fishFollow.SetWaypoints(randomWaypoints);
            }
        }
    }
}
