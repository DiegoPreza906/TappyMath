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
        StartCoroutine(DeactivateAndReactivate());
    }

    private IEnumerator DeactivateAndReactivate()
    {
        boxCollider.enabled = false; // Desactivar el objeto que tiene el trigger
        activationDelay = RandomNumbre();
        Debug.Log("Soy Random" + activationDelay);
        yield return new WaitForSecondsRealtime(activationDelay); // Esperar el tiempo determinado en segundos
        boxCollider.enabled = true;
    }

    private float RandomNumbre()
    {
        return Random.Range(10.0f, 15.0f);
    }
}
