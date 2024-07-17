using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananasMovemente : MonoBehaviour
{
     // Inicializado a true para que las bananas se muevan al principio



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DestroyB"))
        {
            Debug.Log("Adios me voy");
            Destroy(gameObject);
        }
    }
 

}
