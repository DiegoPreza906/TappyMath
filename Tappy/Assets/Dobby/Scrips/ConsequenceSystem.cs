using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Variable para almacenar la cantidad de vidas del jugador
    public int vidas = 3;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject vidaNormalUI; // Referencia a la UI de vida normal
    [SerializeField] private GameObject vidaMuriendoUI; // Referencia a la UI de vida muriendo

    // Método para llamar cuando el jugador se equivoque
    public void WrongAnswer()
    {
        // Reducir la cantidad de vidas
        vidas--;

        Debug.Log("Penalizar al jugador. Vidas restantes: " + vidas);

        // Desactivar la UI de vida normal y activar la UI de vida muriendo
        vidaNormalUI.SetActive(false);
        vidaMuriendoUI.SetActive(true);

        // Verificar si las vidas se han agotado
        if (vidas <= 0)
        {
            // Detener el juego configurando la escala de tiempo a 0
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            Debug.Log("El jugador ha perdido todas sus vidas. El juego se detendrá.");
        }
    }
}
