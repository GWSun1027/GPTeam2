using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour

{
    public GameObject groundTile;
    GameObject lastTile;
    GameObject player;
    //Vector3 nextSpawnPoint;

    public void SpawnTile()
	{
        Vector3 nextSpawnPoint = lastTile.transform.GetChild(1).transform.position;
        lastTile = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        //nextSpawnPoint = lastTile.transform.GetChild(1).transform.position;
	}

    private void Update()
    {
        if (Vector3.Distance(lastTile.transform.position, player.transform.position) < 30)
        {
            SpawnTile();

            GroundTile[] groundTiles = GameObject.FindObjectsOfType<GroundTile>();
            GameObject firstTile = groundTiles[groundTiles.Length - 1].gameObject;
            GameObject.Destroy(firstTile);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastTile = Instantiate(groundTile, new Vector3(), Quaternion.identity);
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }
}
