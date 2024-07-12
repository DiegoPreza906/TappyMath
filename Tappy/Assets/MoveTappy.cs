using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTappy : MonoBehaviour
{
    public float moveDistance = 1.0f; // Distancia a moverse por cada toque de la tecla
    public float moveSpeed = 5.0f; // Velocidad del movimiento
    private Vector3 targetPosition; // Posici�n objetivo
    private Vector3 previousPosition; // Posici�n anterior
    private bool canMove = true; // Flag para controlar el movimiento


    [SerializeField] private Animator triggerAnimator;
    [SerializeField] private string animationTriggerName = "Derecha";
    void Start()
    {
        // Inicializar la posici�n objetivo y anterior a la posici�n actual
        targetPosition = transform.position;
        previousPosition = transform.position;
        QuestionTrigger questionTrigger = FindObjectOfType<QuestionTrigger>();
    }

    void Update()
    {
        if (canMove)
        {
            // Comprobar si se presiona la tecla de flecha derecha
             if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                previousPosition = targetPosition; // Guardar la posici�n actual como anterior
                triggerAnimator.SetTrigger(animationTriggerName);
                targetPosition -= new Vector3(0, 0, moveDistance);

            }

            // Comprobar si se presiona la tecla de flecha izquierda
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                previousPosition = targetPosition; // Guardar la posici�n actual como anterior
                triggerAnimator.SetTrigger(animationTriggerName);
                targetPosition += new Vector3(0, 0, moveDistance);
            }

            // Mover el objeto hacia la posici�n objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void ActiveMovement()
    {
        canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall")) // Verificar si colisiona con un objeto etiquetado como "Wall"
        {
            targetPosition = previousPosition; // Revertir la posici�n objetivo a la anterior
        }
    }

}
