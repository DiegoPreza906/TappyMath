using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Variable para almacenar la cantidad de vidas del jugador
    public int vidas = 3;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject vida3UI; // Referencia a la UI de 3 vidas
    [SerializeField] private GameObject vida2UI; // Referencia a la UI de 2 vidas
    [SerializeField] private GameObject vida1UI; // Referencia a la UI de 1 vida
    [SerializeField] private Animator vidaMuriendo3Animator; // Animator de la UI de vida muriendo para 3 vidas
    [SerializeField] private Animator vidaMuriendo2Animator; // Animator de la UI de vida muriendo para 2 vidas
    [SerializeField] private Animator vidaMuriendo1Animator; // Animator de la UI de vida muriendo para 1 vida

    // Método para llamar cuando el jugador se equivoque
    public void WrongAnswer()
    {
        // Reducir la cantidad de vidas
        vidas--;

        Debug.Log("Penalizar al jugador. Vidas restantes: " + vidas);

        // Desactivar la UI de vida actual y activar la UI de vida muriendo correspondiente
        if (vidas == 2)
        {
            vida3UI.SetActive(false);
            PlayDeathAnimation(vidaMuriendo3Animator);
        }
        else if (vidas == 1)
        {
            vida2UI.SetActive(false);
            PlayDeathAnimation(vidaMuriendo2Animator);
        }
        else if (vidas <= 0)
        {
            vida1UI.SetActive(false);
            PlayDeathAnimation(vidaMuriendo1Animator);

            // Detener el juego configurando la escala de tiempo a 0
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            Debug.Log("El jugador ha perdido todas sus vidas. El juego se detendrá.");
            return;
        }
    }

    // Método para reproducir la animación de muerte y luego actualizar la UI de vida
    private void PlayDeathAnimation(Animator animator)
    {
        // Activar el objeto y reproducir la animación
        animator.gameObject.SetActive(true);
        animator.SetTrigger("Muerte"); // "Muerte" es el nombre del trigger en el animator

        // Después de un tiempo, actualizar la UI de vida
        Invoke(nameof(UpdateLifeUI), 1.0f); // Ajusta el tiempo según la duración de la animación
    }

    private void UpdateLifeUI()
    {
        if (vidas == 2)
        {
            vidaMuriendo3Animator.gameObject.SetActive(false);
            vida2UI.SetActive(true);
        }
        else if (vidas == 1)
        {
            vidaMuriendo2Animator.gameObject.SetActive(false);
            vida1UI.SetActive(true);
        }
        else if (vidas <= 0)
        {
            vidaMuriendo1Animator.gameObject.SetActive(false);
        }
    }
}
