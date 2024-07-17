using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

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
        posicinFijaIz = new Vector3(-0.988f, 0.749f, 0.4281f); // Ajusta los valores según la posición que desees
        posicinFijaDe = new Vector3(1.012f, 0.749f, 0.4281f);

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
                previousPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calcular la diferencia en la posición del toque
                Vector3 touchDelta = new Vector3(touch.position.x,touch.position.y, 0.4281f) - previousPosition;

                // Solo considerar el movimiento si la distancia en Y es mayor que minSwipeDistance
                if (Mathf.Abs(touchDelta.x) > minSwipeDistance)
                {
                    AudioManager.instance.SFXPlay("Dash");

                    if (touchDelta.x > 0) // Deslizamiento hacia la derecha
                    {
                        // Guardar la posición actual como anterior
                        targetPosition += new Vector3(moveDistance, 0, 0);
                        if (targetPosition.x > posicinFijaDe.x)
                        {
                            targetPosition = posicinFijaDe;
                        }
                    }
                    else if (touchDelta.x < 0) // Deslizamiento hacia la izquierda
                    {
                        targetPosition -= new Vector3(moveDistance, 0, 0);
                        if (targetPosition.x < posicinFijaIz.x)
                        {
                            targetPosition = posicinFijaIz;
                        }
                    }

                    // Actualizar la posición anterior al final del movimiento
                    previousPosition = touch.position;
                }
            }
        }

        // Aplicar movimiento suavizado hacia el objetivo en el eje Z
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }

    public void ActiveMovement()
    {
        canMove = true;
    }

    public void StopMovement()
    {
        canMove = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall")) // Verificar si colisiona con un objeto etiquetado como "Wall"
        {
            targetPosition = previousPosition; // Revertir la posición objetivo a la anterior
        }
    }
}
