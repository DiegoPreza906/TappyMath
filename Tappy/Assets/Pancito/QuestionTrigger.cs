using UnityEngine;
using System.Collections;

public class QuestionTrigger : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Animator triggerAnimator;
    [SerializeField] private string animationTriggerName = "Run"; // Nombre del trigger de la animación
    private float activationDelay = 10.0f;
    public BoxCollider boxCollider;


    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Buscar el GameController en la escena
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Player entered the trigger"); 

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
        Debug.Log("Se activa trigger 1");
        Debug.Log("Activation Delay: " + activationDelay);
        StartCoroutine(DeactivateAndReactivate());
    }

    private IEnumerator DeactivateAndReactivate()
    {
        boxCollider.enabled = false; // Desactivar el objeto que tiene el trigger
        Debug.Log("Se activa trigger 2");
        yield return new WaitForSecondsRealtime(activationDelay); // Esperar el tiempo determinado en segundos
        Debug.Log("Se activa trigger 3");
        boxCollider.enabled = true;
    }
}
