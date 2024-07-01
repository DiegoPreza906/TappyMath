using UnityEngine;
using System.Collections;

public class QuestionTrigger : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private float activationDelay = 10.0f; // Tiempo en segundos para volver a activar el trigger

    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Buscar el GameController en la escena
        //gameObject.SetActive(false); // Desactivar el objeto que tiene el trigger
    }

    void Update()
    {
        transform.position += new Vector3(-4, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Player entered the trigger"); // Añadir mensaje de depuración
            Time.timeScale = 0;
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
