using UnityEngine;

public class MoveTappy : MonoBehaviour
{
    private Vector3 posicinFijaDe; // Posición fija derecha en el eje Z
    private Vector3 posicinFijaIz; // Posición fija izquierda en el eje Z
    public float moveDistance = 1f; // Distancia de movimiento en el eje Z
    private Vector3 previousPosition;
    private Vector3 targetPosition;
    private bool canMove = true;
    private float minSwipeDistance = 50f; // Distancia mínima para considerar un deslizamiento

    void Start()
    {
        // Inicializar las posiciones fijas en el eje Z
        posicinFijaIz = new Vector3(0.4281f, 0.749f, 1.012f); // Ajusta los valores según la posición que desees
        posicinFijaDe = new Vector3(0.4281f, 0.749f, -0.988f); // Ajusta los valores según la posición que desees

        // Establecer la posición inicial y objetivo como la posición actual del objeto
        targetPosition = transform.position;
        previousPosition = transform.position;
    }

    void Update()
    {
        if (canMove && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Guardar la posición inicial del toque
                previousPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calcular la diferencia en la posición del toque
                Vector3 touchDelta = new Vector3(touch.position.x, touch.position.y, 0) - previousPosition;

                // Solo considerar el movimiento si la distancia en Y es mayor que minSwipeDistance
                if (Mathf.Abs(touchDelta.y) > minSwipeDistance)
                {
                    if (touchDelta.z > 0) // Deslizamiento hacia arriba (adelante en eje Z)
                    {
                        previousPosition = touch.position; // Actualizar la posición anterior
                        targetPosition = posicinFijaDe; // Mover hacia la posición fija derecha en el eje Z
                    }
                    else if (touchDelta.z < 0) // Deslizamiento hacia abajo (atrás en eje Z)
                    {
                        previousPosition = touch.position; // Actualizar la posición anterior
                        targetPosition = posicinFijaIz; // Mover hacia la posición fija izquierda en el eje Z
                    }
                }
            }
        }

        // Aplicar movimiento suavizado hacia el objetivo en el eje Z
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
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
