using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerH : MonoBehaviour
{
    public int vidas = 3;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private ModificarFinal GO;
    [SerializeField] private GuardarPuntos guardar;
    [SerializeField] private GameObject vida3UI; // Referencia a la UI de 3 vidas
    [SerializeField] private GameObject vida2UI; // Referencia a la UI de 2 vidas
    [SerializeField] private GameObject vida1UI; // Referencia a la UI de 1 vida

    [SerializeField] private GameObject animatorObject3; // Referencia al GameObject que tiene el Animator para 3 vidas
    [SerializeField] private GameObject animatorObject2; // Referencia al GameObject que tiene el Animator para 2 vidas
    [SerializeField] private GameObject animatorObject1; // Referencia al GameObject que tiene el Animator para 1 vida

    private Animator animator3;
    private Animator animator2;
    private Animator animator1;

    private void Start()
    {
        if (animatorObject3 != null)
        {
            animator3 = animatorObject3.GetComponent<Animator>();
            animator3.SetInteger("Vidas", vidas); // Inicializar el par�metro de vidas
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto con el Animator para 3 vidas.");
        }

        if (animatorObject2 != null)
        {
            animator2 = animatorObject2.GetComponent<Animator>();
            animator2.SetInteger("Vidas", vidas); // Inicializar el par�metro de vidas
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto con el Animator para 2 vidas.");
        }

        if (animatorObject1 != null)
        {
            animator1 = animatorObject1.GetComponent<Animator>();
            animator1.SetInteger("Vidas", vidas); // Inicializar el par�metro de vidas
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto con el Animator para 1 vida.");
        }
    }

    public void WrongAnswer()
    {
        // Reducir la cantidad de vidas
        vidas--;

        Debug.Log("Penalizar al jugador. Vidas restantes: " + vidas);

        // Actualizar los par�metros del Animator si se han asignado correctamente
        if (vidas == 2)
        {

            if (animator3 != null)
            {
                animator3.SetTrigger("LoseLife3");
            }
        }
        else if (vidas == 1)
        {

            if (animator2 != null)
            {
                animator2.SetTrigger("LoseLife2");
            }
        }
        else if (vidas <= 0)
        {

            if (animator1 != null)
            {
                animator1.SetTrigger("LoseLife1");
            }
            // Detener el juego configurando la escala de tiempo a 0
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            AudioManager.instance.musicSources.Stop();
            AudioManager.instance.SFXPlay("Over");
            GO.ContarFinal();
            guardar.EjemploFinalizarPartida();
            Debug.Log("El jugador ha perdido todas sus vidas. El juego se detendr�.");
            return;
        }
    }
}
