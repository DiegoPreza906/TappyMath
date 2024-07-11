using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananasMovemente : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(-5, 0, 0) * Time.deltaTime;
    }
}
