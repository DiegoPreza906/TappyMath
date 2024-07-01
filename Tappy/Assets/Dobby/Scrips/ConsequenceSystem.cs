using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Variable para almacenar la cantidad de vidas del jugador
    public int vidas = 3;

    [SerializeField] private GameObject gameOverCanvas;

    // Método para llamar cuando el jugador se equivoque
    public void WrongAnswer()
    {
        // Reducir la cantidad de vidas
        vidas--;

        Debug.Log("Penalizar al jugador. Vidas restantes: " + vidas);

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
