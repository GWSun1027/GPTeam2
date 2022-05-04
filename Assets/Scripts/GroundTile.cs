using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

	private void OnTriggerExit(Collider other)
	{
        Debug.Log("Exited previous tile");
        groundSpawner.SpawnTile();
        Destroy(gameObject, 1);
	}

	// Update is called once per frame
	void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
	{
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
	}
}
