using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    private bool playOn = false;
    private bool followPlayer = false;
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
            // Cambiar la posición y rotación de la cámara a valores específicos
            Vector3 targetPosition = new Vector3(-3.9f, 2.9f, -0.043f);
            Quaternion targetRotation = Quaternion.Euler(0, 90, 0);

            // Interpolación suave hacia la nueva posición y rotación
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 4);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 4);

            // Verificar si la cámara está cerca de la posición y rotación objetivo
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f &&
                Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
                transform.position = targetPosition;
                transform.rotation = targetRotation;
                playOn = false;
                followPlayer = true; // Activar seguimiento del jugador
                
            }
        }
    }

    private void LateUpdate()
    {
        if (followPlayer)
        {
            // Solo seguir al jugador en el eje Z suavemente
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 4);
        }
    }

    // Método para activar el seguimiento de la cámara
    public void SetPlayOn(bool play)
    {
        playOn = play;
        followPlayer = false; // Reiniciar seguimiento del jugador
    }
}
