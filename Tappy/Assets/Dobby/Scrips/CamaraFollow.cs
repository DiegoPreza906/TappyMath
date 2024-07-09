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
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playOn)
        {
            Debug.Log("Hola ya cambie");
            // Cambiar la posici�n y rotaci�n de la c�mara a valores espec�ficos
            Vector3 targetPosition = new Vector3(-3.9f, 2.9f, -0.043f);
            Quaternion targetRotation = Quaternion.Euler(0, 90, 0);

            // Interpolaci�n suave hacia la nueva posici�n y rotaci�n
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 4);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 4);

            // Verificar si la c�mara est� cerca de la posici�n y rotaci�n objetivo
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f &&
                Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.position = targetPosition;
                transform.rotation = targetRotation;
                playOn = false;
            }
        }
    }

    // M�todo para activar el seguimiento de la c�mara
    public void SetPlayOn(bool play)
    {
        playOn = play;
    }
}
