using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    // Spawn positions
    public Transform[] spawnPositions;

    // Time interval between spawns
    public float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBananas());
    }
 
    IEnumerator SpawnBananas()
    {
        while (true)
        {
            // Randomly decide how many positions to spawn at (1 to 3)
            int numberOfPositionsToSpawn = Random.Range(1, spawnPositions.Length + 1);

            // Shuffle the spawn positions array
            Transform[] shuffledPositions = spawnPositions.OrderBy(x => Random.value).ToArray();

            for (int i = 0; i < numberOfPositionsToSpawn; i++)
            {
                // Randomly select a prefab to spawn
                int prefabIndex = Random.Range(0, prefabs.Length);
                Instantiate(prefabs[prefabIndex], shuffledPositions[i].position, Quaternion.identity);
            }

            // Wait for the next spawn
            spawnInterval = Random.Range(7,10);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void DespuesEstar()
    {
        StartCoroutine(SpawnBananas());
    }
}
