using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float speed;
    public float cooldown;
    private float nextReadyTime = 0f;
    private float lastSpawnY;
    void Start()
    {
    }

    void Update()
    {
        if (Time.time >= nextReadyTime)
        {
            spawnObstacles();
            nextReadyTime = Time.time + cooldown;
        }
    }

    private void spawnObstacles()
    {
        float y;

        do
        {
            y = Random.Range(3.1F, -3.4F);
        } while (Math.Abs(y - lastSpawnY) >= 2.3);
        
        GameObject obstacleInstance = Instantiate(obstacle, new Vector3(5, y, 0), Quaternion.identity);
        lastSpawnY = y;
    }
   
}
