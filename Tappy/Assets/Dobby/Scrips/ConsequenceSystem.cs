using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Variable para almacenar la cantidad de vidas del jugador
    public int vidas = 3;

    //[SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject vida3UI; // Referencia a la UI de 3 vidas
    [SerializeField] private GameObject vida2UI; // Referencia a la UI de 2 vidas
    [SerializeField] private GameObject vida1UI; // Referencia a la UI de 1 vida
    [SerializeField] private GameObject vidaMuriendo3UI; // Referencia a la UI de muerte para la 3ª vida
    [SerializeField] private GameObject vidaMuriendo2UI; // Referencia a la UI de muerte para la 2ª vida
    [SerializeField] private GameObject vidaMuriendo1UI; // Referencia a la UI de muerte para la 1ª vida

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
            vidaMuriendo3UI.SetActive(true);
        }
        else if (vidas == 1)
        {
            vida2UI.SetActive(false);
            vidaMuriendo2UI.SetActive(true);
        }
        else if (vidas <= 0)
        {
            vida1UI.SetActive(false);
            vidaMuriendo1UI.SetActive(true);

            // Detener el juego configurando la escala de tiempo a 0
            Time.timeScale = 0;
            //gameOverCanvas.SetActive(true);
            Debug.Log("El jugador ha perdido todas sus vidas. El juego se detendrá.");
            return;
        }

        // Después de un corto tiempo, cambiar a la UI de la siguiente vida
        Invoke(nameof(UpdateLifeUI), 0.5f); // Cambia el tiempo según sea necesario
    }

    private void UpdateLifeUI()
    {
        if (vidas == 2)
        {
            vidaMuriendo3UI.SetActive(false);
            vida2UI.SetActive(true);
        }
        else if (vidas == 1)
        {
            vidaMuriendo2UI.SetActive(false);
            vida1UI.SetActive(true);
        }
    }
}
