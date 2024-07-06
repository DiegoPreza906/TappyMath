using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody rb;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(-4, 0, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Active"))
        {
            transform.position = new Vector3(18, transform.position.y, transform.position.z);
            //rb.isKinematic = false;
            isMoving = false;
            Debug.Log("Object moved to new position and resumed movement.");
        }

    }

    public void StopMovement()
    {
        Debug.Log("Stopping movement.");
        isMoving = true;
    }

    public void ActiveMovement()
    {
        Debug.Log("Resuming movement.");
        isMoving = false;
    }
}
