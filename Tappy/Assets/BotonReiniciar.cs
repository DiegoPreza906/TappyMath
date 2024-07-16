using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonReiniciar : MonoBehaviour
{
    public void VolverAEscena1()
    {
        AudioManager.instance.MusicPlay("Theeme");
        SceneManager.LoadScene("Nivel1");
        Time.timeScale = 1.0f;
    }
}
