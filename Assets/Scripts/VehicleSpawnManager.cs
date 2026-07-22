using UnityEngine;

public class VehicleSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float startDelay = 2.0f;
    [SerializeField] private float spawnInterval = 1.5f;
    
    void Start()
    {
        InvokeRepeating(gameObject.name, startDelay, spawnInterval);
    }

    void SpawnMiddle()
    {

            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], gameObject.transform.position, gameObject.transform.rotation);
    }

    // Spawn random vehicle from left side
    void SpawnLeft()
    {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], gameObject.transform.position, gameObject.transform.rotation);
    } 

    // Spawn random vehicle from right side
    void SpawnRight()
    {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], gameObject.transform.position, obstaclePrefabs[obstacleIndex].transform.rotation);
    } 
}
