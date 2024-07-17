using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody rb;
    private bool isMoving = false;
    private float velocidad = 5.0f;
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
            transform.position += new Vector3(0, 0, -velocidad) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Active"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 42.31f);
            //rb.isKinematic = false;
            isMoving = false;
        }

    }

    public void StopMovement()
    {
        isMoving = true;
    }

    public void ActiveMovement()
    {
        isMoving = false;
    }

    public void Aumentar()
    {
        velocidad += 1.0f;
    }
}
