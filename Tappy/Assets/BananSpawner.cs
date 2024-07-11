using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananSpawner : MonoBehaviour
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
            foreach (Transform position in spawnPositions)
            {
                // Randomly decide how many prefabs to spawn at this position (0 to 3)
                int numberOfPrefabsToSpawn = Random.Range(1, 4); // 1 to 3

                for (int i = 0; i < numberOfPrefabsToSpawn; i++)
                {
                    // Randomly select a prefab to spawn
                    int prefabIndex = Random.Range(0, prefabs.Length);
                    Instantiate(prefabs[prefabIndex], position.position, Quaternion.identity);
                }
            }
            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
