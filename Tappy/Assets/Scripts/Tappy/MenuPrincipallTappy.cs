using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuPrincipalTappy : MonoBehaviour
{
    private Moving[] movingObjects; // Array de referencias a los objetos en movimiento
    public MoveTappy moveTappy; // Start is called before the first frame update
    public CamaraFollow camara;
    // Animaciones
    [SerializeField] private string animationRun = "Correr";
    [SerializeField] private Animator triggerAnimator;

    [SerializeField] private GameObject gameObjectQuestion;

    [SerializeField] private GameObject lifes;

    [SerializeField] private GameObject contador;// Nota: cambio de "Lifes" a "lifes" para seguir las convenciones de nomenclatura

    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject triggerQuestion;

    [SerializeField] private GameObject SpawnBananas;

    [SerializeField] private GameObject score;

    [SerializeField] private StopBananas bananas;

    [SerializeField] private GameObject botonInicio;

    void Awake()
    {
        movingObjects = FindObjectsOfType<Moving>();
        foreach (Moving movingObject in movingObjects)
        {
            movingObject.StopMovement();
        }
        moveTappy.StopMovement();
        gameObjectQuestion.SetActive(false);
        lifes.SetActive(false);
        contador.SetActive(false);
        triggerQuestion.SetActive(false);
        score.SetActive(false);
        SpawnBananas.SetActive(false);
        bananas.StopMovement();

    }

    // Update is called once per frame
  
    public void Onclick()
    {
        PicarPantalla();
    }

    public void PicarPantalla()
    {

        AudioManager.instance.ToggleMusic();

        AudioManager.instance.MusicPlay("Theme");

        moveTappy.ActiveMovement();

        foreach (Moving movingObject in movingObjects)
        {
            movingObject.ActiveMovement();
        }
        triggerAnimator.SetTrigger(animationRun);

        gameObjectQuestion.SetActive(true);

        lifes.SetActive(true);

        menu.SetActive(false);

        botonInicio.SetActive(false);

        triggerQuestion.SetActive(true);

        contador.SetActive(true);

        SpawnBananas.SetActive(true);

        bananas.ActiveMovement();

        score.SetActive(true);

        camara.SetPlayOn(true);
    }
}
