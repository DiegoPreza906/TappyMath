using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private bool playOn = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializa la posición de la cámara pegada al objetivo
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playOn)
        {
            // Sigue al objetivo desde atrás
            Vector3 targetPosition = target.position + new Vector3(0, 1, -1); // Ajusta estos valores según lo necesites
            transform.position = Vector3.Lerp(transform.position, targetPosition + offset, Time.deltaTime * 4);
        }
    }
}
