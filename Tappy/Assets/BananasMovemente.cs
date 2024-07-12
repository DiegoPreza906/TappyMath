using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananasMovemente : MonoBehaviour
{
    private bool isMoving = true; // Inicializado a true para que las bananas se muevan al principio

    void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(-5, 0, 0) * Time.deltaTime;
        }
        else
        {
            // Banana stops moving
        }
    }

    public void StopMovement()
    {
        Debug.Log("Stopping movement. Bananas");
        isMoving = false;
    }

    public void ActiveMovement()
    {
        Debug.Log("Resuming movement.");
        isMoving = true;
    }
}
