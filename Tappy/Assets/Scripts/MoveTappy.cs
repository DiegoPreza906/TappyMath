using UnityEngine;

public class MoveTappy : MonoBehaviour
{
    private Vector3 posicinFijaDe; // Posici�n fija derecha en el eje Z
    private Vector3 posicinFijaIz; // Posici�n fija izquierda en el eje Z
    public float moveDistance = 1f; // Distancia de movimiento en el eje Z
    private Vector3 previousPosition;
    private Vector3 targetPosition;
    private bool canMove = true;
    private float minSwipeDistance = 50f; // Distancia m�nima para considerar un deslizamiento

    void Start()
    {
        // Inicializar las posiciones fijas en el eje Z
        posicinFijaIz = new Vector3(0.4281f, 0.749f, 1.012f); // Ajusta los valores seg�n la posici�n que desees
        posicinFijaDe = new Vector3(0.4281f, 0.749f, -0.988f); // Ajusta los valores seg�n la posici�n que desees

        // Establecer la posici�n inicial y objetivo como la posici�n actual del objeto
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
                // Guardar la posici�n inicial del toque
                previousPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calcular la diferencia en la posici�n del toque
                Vector3 touchDelta = new Vector3(touch.position.x, touch.position.y, 0) - previousPosition;

                // Solo considerar el movimiento si la distancia en Y es mayor que minSwipeDistance
                if (Mathf.Abs(touchDelta.y) > minSwipeDistance)
                {
                    AudioManager.instance.SFXPlay("Dash");
                    if (touchDelta.z > 0) // Deslizamiento hacia arriba (adelante en eje Z)
                    {
                        previousPosition = touch.position; // Actualizar la posici�n anterior
                        targetPosition = posicinFijaDe; // Mover hacia la posici�n fija derecha en el eje Z
                    }
                    else if (touchDelta.z < 0) // Deslizamiento hacia abajo (atr�s en eje Z)
                    {
                        previousPosition = touch.position; // Actualizar la posici�n anterior
                        targetPosition = posicinFijaIz; // Mover hacia la posici�n fija izquierda en el eje Z
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
            targetPosition = previousPosition; // Revertir la posici�n objetivo a la anterior
        }
    }
}
