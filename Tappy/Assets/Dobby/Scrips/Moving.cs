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
        if (isMoving==true)
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
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Active"))
        {
            rb.isKinematic = false;
        }
    }

    public void StopMovement()
    {
        Debug.Log("Si llegas");
        isMoving = true;
        transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
    }
    public void ActiveMovement()
    {
        isMoving = false;
        transform.position += new Vector3(-4, 0, 0) * Time.deltaTime;
    }

}
