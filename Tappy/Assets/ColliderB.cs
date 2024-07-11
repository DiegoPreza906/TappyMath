using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderB : MonoBehaviour
{
    private ContadorBnanas bananaCounter;

    private void Start()
    {
        // Buscar el ContadorBnanas en la escena
        GameObject counterObject = GameObject.FindWithTag("BananaCounter");
        if (counterObject != null)
        {
            bananaCounter = counterObject.GetComponent<ContadorBnanas>();
        }
        else
        {
            Debug.LogWarning("No se encontró un objeto con la etiqueta 'BananaCounter'.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            if (bananaCounter != null)
            {
                bananaCounter.IncrementBananaCount();
                Debug.Log("Incrementando contador de plátanos");
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("bananaCounter no está asignado.");
            }
        }
        else if (other.CompareTag("DestroyB"))
        {
            Debug.Log("Adios me voy");
            Destroy(gameObject);
        }
    }
}
