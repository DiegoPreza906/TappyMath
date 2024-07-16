using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SceneMan : MonoBehaviour
{
    public TextMeshProUGUI textProgress;
    public Slider sliderProgress;
    public string sceneLoadName;
    [SerializeField] private GameObject Load; // Referencia a la UI de carga

    private void Start()
    {
        Load.SetActive(false);
        sliderProgress.value = 0;
    }

    private void Update()
    {
        // Movimiento suave de la barra de progreso (opcional, ya que no es asincrónica)
        if (Load.activeSelf)
        {
            sliderProgress.value = Mathf.Lerp(sliderProgress.value, 1f, Time.deltaTime * 10f);
        }
    }

    public void LoadSceneButton()
    {
        if (!Load.activeSelf)
        {
            Load.SetActive(true);
            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        // Mostrar la UI de carga
        textProgress.text = "Loading.. 0%";

        // Cargar la escena sincrónicamente
        yield return new WaitForEndOfFrame(); // Esperar un frame para actualizar la UI

        SceneManager.LoadScene(sceneLoadName);

        // Actualizar la UI de carga
        textProgress.text = "Loading.. 100%";
        sliderProgress.value = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
