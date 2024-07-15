using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MoveTappy : MonoBehaviour
{
    public float moveDistance = 1.0f; // Distancia a moverse por cada toque de la tecla
    public float moveSpeed = 5.0f; // Velocidad del movimiento
    private Vector3 targetPosition; // Posición objetivo
    private Vector3 previousPosition; // Posición anterior
    private bool canMove = true; // Flag para controlar el movimiento
    private Vector3 posicinFijaIz;
    private Vector3 posicinFijaDe;

    [SerializeField] private Animator triggerAnimator;
    //[SerializeField] private string animationTriggerName = "Derecha";
    void Start()
    {
        // Inicializar la posición objetivo y anterior a la posición actual
        targetPosition = transform.position;
        previousPosition = transform.position;
        posicinFijaIz = new Vector3(0.4281f, 0.749f, 1.012f);
        posicinFijaDe = new Vector3(0.4281f, 0.749f, -0.988f);
        QuestionTrigger questionTrigger = FindObjectOfType<QuestionTrigger>();
    }

    void Update()
    {
        if (canMove)
        {
            // Manejo de entrada táctil
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Guardar la posición inicial del toque
                    previousPosition = touch.position;
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    // Calcular la diferencia en la posición del toque
                    Vector3 touchDelta = touch.deltaPosition;

                    if (touchDelta.x > 0) // Deslizamiento hacia la derecha
                    {
                        previousPosition = posicinFijaDe; // Guardar la posición actual como anterior
                        targetPosition -= new Vector3(0, 0, moveDistance);
                        if (targetPosition.z < posicinFijaDe.z)
                        {
                            targetPosition = posicinFijaDe;
                        }
                    }
                    else if (touchDelta.x < 0) // Deslizamiento hacia la izquierda
                    {
                        previousPosition = posicinFijaIz;
                        targetPosition += new Vector3(0, 0, moveDistance);
                        if (targetPosition.z > posicinFijaIz.z)
                        {
                            targetPosition = posicinFijaIz;
                        }
                    }
                }
            }

            // Manejo de entrada de ratón para pruebas en la computadora
            if (Input.GetMouseButtonDown(0))
            {
                // Guardar la posición inicial del clic del ratón
                previousPosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                // Calcular la diferencia en la posición del ratón
                Vector3 mouseDelta = (Vector3)Input.mousePosition - previousPosition;

                if (mouseDelta.x > 0) // Arrastre hacia la derecha
                {
                    previousPosition = posicinFijaDe; // Guardar la posición actual como anterior
                    targetPosition -= new Vector3(0, 0, moveDistance);
                    if (targetPosition.z < posicinFijaDe.z)
                    {
                        targetPosition = posicinFijaDe;
                    }
                }
                else if (mouseDelta.x < 0) // Arrastre hacia la izquierda
                {
                    previousPosition = posicinFijaIz;
                    targetPosition += new Vector3(0, 0, moveDistance);
                    if (targetPosition.z > posicinFijaIz.z)
                    {
                        targetPosition = posicinFijaIz;
                    }
                }

                // Actualizar la posición anterior del ratón
                previousPosition = Input.mousePosition;
            }

            // Mover el objeto hacia la posición objetivo
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
       
            targetPosition = previousPosition; // Revertir la posición objetivo a la anterior
        }
    }

}
