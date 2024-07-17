using UnityEngine;
using System.IO;
using TMPro;

[System.Serializable]
public class PlayerProgress
{
    public int bananasRecogidas;
    public float score;
}

public class GuardarPuntos : MonoBehaviour
{
    private string filePath;
    private PlayerProgress playerProgress;
    [SerializeField] public ContadorBnanas ContadorB;
    [SerializeField] public Score ContadorS;

    public TextMeshProUGUI ProgresoB;
    public TextMeshProUGUI ProgresoS;

    void Start()
    {
        filePath = Application.persistentDataPath + "/playerProgress.json";
        CargarProgreso(); // Cargar el progreso al iniciar la partida (si existe)

        // Inicializar datos si es necesario
        if (playerProgress == null)
        {
            playerProgress = new PlayerProgress();
            playerProgress.bananasRecogidas = 0;
            playerProgress.score = 0;
        }
    }

    void GuardarProgreso()
    {
        string json = JsonUtility.ToJson(playerProgress);
        File.WriteAllText(filePath, json);
        Debug.Log("Progreso guardado.");
    }

    void CargarProgreso()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerProgress = JsonUtility.FromJson<PlayerProgress>(json);
            ProgresoB.text = "" + playerProgress.bananasRecogidas;
            ProgresoS.text = "" + playerProgress.score;
            Debug.Log("Progreso cargado. Bananas recogidas: " + playerProgress.bananasRecogidas + ", Score: " + playerProgress.score);
        }
        else
        {
            Debug.Log("No se encontró el archivo de progreso. Creando uno nuevo.");
            playerProgress = new PlayerProgress();
            playerProgress.bananasRecogidas = 0;
            playerProgress.score = 0;
            ProgresoB.text = "" + playerProgress.bananasRecogidas;
            ProgresoS.text = "" + playerProgress.score;
        }
    }

    // Método para actualizar el progreso al final de cada partida
    public void ActualizarProgreso(int bananasRecogidas, float score)
    {
        playerProgress.bananasRecogidas += bananasRecogidas;
        if(playerProgress.score<score)
        {
            playerProgress.score = score;
        }
        GuardarProgreso(); // Guardar el progreso actualizado
    }

    // Ejemplo de cómo podrías llamar a ActualizarProgreso desde otro script al final de cada partida
    public void EjemploFinalizarPartida()
    {
        int bananasRecogidasAlFinalizar = ContadorB.RegresarContador();
        float scoreAlFinalizar = ContadorS.RegresarScore();

        Debug.Log("HOLA ya finalice");
        ActualizarProgreso(bananasRecogidasAlFinalizar, scoreAlFinalizar);
    }
}
