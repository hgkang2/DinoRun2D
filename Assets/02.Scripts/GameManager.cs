using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public float spawnDelay;
    private float spawnTimer;
    public bool isSpawning;
    private int spawnTracker;
    void Start()
    {
        spawnTimer = spawnDelay;

    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawning.Equals(true))
        {
            spawnTimer -= Time.deltaTime;
                if(spawnTimer < 0)
            {
                spawnTimer = spawnDelay;
                spawnTimer = Random.Range(0, obstacles.Length);
                if (spawnTracker.Equals(4))
                {
                    int randPoint = 2 + Random.Range(0, 3);
                    Instantiate(obstacles[spawnTracker], spawnPoints[randPoint].position, spawnPoints[randPoint].rotation);
                }
                else if (spawnTracker.Equals(0))
                {
                    Instantiate(obstacles[spawnTracker], spawnPoints[spawnTracker].position, spawnPoints[spawnTracker].rotation);
                }
                else
                {
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[1].rotation);
                }
            }    
        }
    }
}
