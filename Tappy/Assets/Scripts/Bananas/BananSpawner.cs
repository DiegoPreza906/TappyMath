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

    public Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject parentTransform = GameObject.FindWithTag("SaveB");
        StartCoroutine(SpawnBananas());
    }
 
    IEnumerator SpawnBananas()
    {
        while (true)
        {
            // Decidir aleatoriamente cuántas posiciones generar (de 1 a 3)
            int numberOfPositionsToSpawn = Random.Range(1, spawnPositions.Length + 1);

            // Barajar el array de posiciones de generación
            Transform[] shuffledPositions = spawnPositions.OrderBy(x => Random.value).ToArray();

            for (int i = 0; i < numberOfPositionsToSpawn; i++)
            {
                // Seleccionar aleatoriamente un prefab para generar
                int prefabIndex = Random.Range(0, prefabs.Length);
                // Instanciar el prefab en la posición barajada
                GameObject spawnedBanana = Instantiate(prefabs[prefabIndex], shuffledPositions[i].position, Quaternion.identity);
                // Hacer que el objeto generado sea hijo del GameObject padre en la jerarquía
                spawnedBanana.transform.SetParent(parentTransform, true); // Mantener la posición y rotación mundial
            }

            // Esperar hasta la próxima generación
            spawnInterval = Random.Range(7, 10);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void DespuesEstar()
    {
        StartCoroutine(SpawnBananas());
    }
}
