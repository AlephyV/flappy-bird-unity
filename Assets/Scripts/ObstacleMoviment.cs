using UnityEngine;

public class ObstacleMoviment : MonoBehaviour
{
    private GameObject spawnManager;
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("Spawn");
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float speed = spawnManager.GetComponent<SpawnObstacles>().speed;
        gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }
}
