using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
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

}
