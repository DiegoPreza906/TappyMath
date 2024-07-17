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
            Debug.Log("No se encontr� un objeto con la etiqueta 'BananaCounter'.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            if (bananaCounter != null)
            {
                bananaCounter.IncrementBananaCount();
                Debug.Log("Incrementando contador de pl�tanos");
                AudioManager.instance.SFXPlay("Banana");
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("bananaCounter no est� asignado.");
            }
        }
        else if (other.CompareTag("DestroyB"))
        {
            Debug.Log("Adios me voy");
            Destroy(gameObject);
        }
    }
}
