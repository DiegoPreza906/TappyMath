using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBananas : MonoBehaviour
{
    private bool isMoving = false;
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
       
        isMoving = false;
    }

    public void ActiveMovement()
    {
        
        isMoving = true;
    }
}
