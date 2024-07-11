using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderB : MonoBehaviour
{
    [SerializeField] ContadorBnanas bananaCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            Debug.Log("Incrementando contador de plátanos");

            if (bananaCounter != null)
            {
                bananaCounter.IncrementBananaCount();
            }

            Destroy(gameObject);
        }
        else if (other.CompareTag("DestroyB"))
        {
            Destroy(gameObject);
        }
    }
}
