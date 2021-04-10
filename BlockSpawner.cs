using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    //Array of spawn points' transforms
    public Transform[] spawnPoints;
    public GameObject blockPrefab;

    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 2f;
   

    // Update is called once per frame
    void Update()
    {
        //Spawns blocks based on timeBetweenWaves
        if (Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
 
    }

    void SpawnBlocks()
    {
        //Chooses a random index between 0 and 5 (5 indices)
        int randomIndex = Random.Range(0, spawnPoints.Length);

        //Instantiates a block using blockPrefab at each spawn position except for the one with the random index
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {

                //Quaternion.identity means add no rotation
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
