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
    public float currentPorcent;
    [SerializeField] private GameObject Load; // Referencia a la UI de 3 vidas

    private void Start()
    {
        Load.SetActive(false);
    }
    private void Update()
    {
        sliderProgress.value = Mathf.MoveTowards(sliderProgress.value, currentPorcent, 10 * Time.deltaTime);
    }
    public void LoadSceneButton()
    {
        Load.SetActive(true);
        StartCoroutine(LoadScene(sceneLoadName));
    }

    public IEnumerator LoadScene(string sceneLoadName)
    {
        textProgress.text = "Loading.. 00%";
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneLoadName);
        while (!loadAsync.isDone)
        {
            currentPorcent = (loadAsync.progress * 100) / 0.9f;
            textProgress.text = "Loading.."+currentPorcent.ToString("00") + "%";
            yield return null;
        }

        
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
