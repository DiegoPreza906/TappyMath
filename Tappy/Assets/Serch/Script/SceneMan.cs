using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMan : MonoBehaviour
{
    public TextMeshProUGUI textProgress;
    public Slider sliderProgress;
    public string sceneLoadName;
    [SerializeField] private GameObject Load; // Referencia a la UI de carga
    private float currentPorcent;

    private void Start()
    {
        Load.SetActive(false);
        sliderProgress.value = 0;
    }

    private void Update()
    {
        if (Load.activeSelf)
        {
            // Movimiento suave de la barra de progreso
            sliderProgress.value = Mathf.MoveTowards(sliderProgress.value, currentPorcent / 100f, 10 * Time.deltaTime);
        }
    }

    public void LoadSceneButton()
    {
        if (!Load.activeSelf)
        {
            Load.SetActive(true);
            currentPorcent = 0; // Reiniciar porcentaje actual
            StartCoroutine(LoadScene(sceneLoadName));
        }
    }

    public IEnumerator LoadScene(string sceneLoadName)
    {
        textProgress.text = "Loading.. 00%";
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneLoadName);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            currentPorcent = (loadAsync.progress / 0.9f) * 100;
            textProgress.text = "Loading.. " + currentPorcent.ToString("00") + "%";

            if (loadAsync.progress >= 0.9f)
            {
                textProgress.text = "Loading.. 100%";
                sliderProgress.value = 1f;
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
