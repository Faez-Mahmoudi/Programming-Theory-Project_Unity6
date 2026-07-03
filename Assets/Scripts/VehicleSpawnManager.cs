using UnityEngine;

public class VehicleSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    //private float spawnRangeX = 15.0f;
    //private float spawnPosZ = 20.0f;
    //private float sideSpawnMinZ = 3.0f;
    //private float sideSpawnMaxZ = 15.0f;
    //private float sideSpawnX = 20.0f;

    [SerializeField] private float startDelay = 2.0f;
    [SerializeField] private float spawnInterval = 1.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(gameObject.name, startDelay, spawnInterval);
    }

    // Spawn random animal in the scene
    void SpawnMiddle()
    {
        //if (GameManager.Instance.isGameActive)
        //{
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            //Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(obstaclePrefabs[obstacleIndex], gameObject.transform.position, gameObject.transform.rotation);
        //}
    }

    // Spawn random animal from left side
    void SpawnLeft()
    {
        //if (GameManager.Instance.isGameActive)
        //{
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            //Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(obstaclePrefabs[obstacleIndex], gameObject.transform.position, gameObject.transform.rotation);
        //}
    } 

    // Spawn random animal from right side
    void SpawnRight()
    {
        //if (GameManager.Instance.isGameActive)
        //{
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            //Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(obstaclePrefabs[obstacleIndex], gameObject.transform.position, gameObject.transform.rotation);
        //}
    } 
}
