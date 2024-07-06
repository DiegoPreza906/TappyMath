using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;
    public Vector3 newPosition; // Nueva posición a la que deseas mover el objeto

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            if (roadSection != null)
            {
                roadSection.transform.position = newPosition;
                Debug.Log("roadSection moved to new position: " + newPosition);
            }
            else
            {
                Debug.LogError("roadSection reference is missing!");
            }
        }
    }
}
