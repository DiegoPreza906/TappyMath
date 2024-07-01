using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    
    [SerializeField]private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Buscar el GameController en la escena
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Player entered the trigger"); // Añadir mensaje de depuración
            gameController.TriggerQuestion(); // Mostrar la pregunta cuando el jugador entra en el trigger
        }
    }
}
