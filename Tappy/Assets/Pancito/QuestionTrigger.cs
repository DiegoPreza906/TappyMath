using UnityEngine;
using System.Collections;

public class QuestionTrigger : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Animator triggerAnimator;
    [SerializeField] private string animationTriggerName = "Run";// Nombre del trigger de la animación
    [SerializeField] private float activationDelay = 20.0f;

    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Buscar el GameController en la escena
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Player entered the trigger"); // Añadir mensaje de depuración
            // Activar una nueva animación si se ha asignado un Animator
            if (triggerAnimator != null)
            {
                triggerAnimator.SetTrigger(animationTriggerName);
                Debug.Log("Triggered animation: " + animationTriggerName);
            }
            gameController.TriggerQuestion(); // Mostrar la pregunta cuando el jugador entra en el trigger

        }
    }
    public void IniciarCorrutina()
    {
        StartCoroutine(DeactivateAndReactivate());
    }
    public IEnumerator DeactivateAndReactivate()
    {
        gameObject.SetActive(false); // Desactivar el objeto que tiene el trigger
        yield return new WaitForSecondsRealtime(activationDelay); // Esperar el tiempo determinado en segundos
        gameObject.SetActive(true); // Volver a activar el objeto
    }
}
