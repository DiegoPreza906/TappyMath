using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBananas : MonoBehaviour
{
    private bool isMoving = false;
    private float velocidad = 5.0f;
    void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(0, 0, -velocidad) * Time.deltaTime;
        }
        else
        {
            // Banana stops moving
        }
    }

    public void StopMovement()
    {
       
        isMoving = false;
    }

    public void ActiveMovement()
    {
        
        isMoving = true;
    }

    public void Aumentar()
    {
        velocidad += 1.0f;
    }
}
