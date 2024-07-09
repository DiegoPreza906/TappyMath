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
    [SerializeField] private string animationThink = "Run";
    [SerializeField] private string animationRun = "Correr";
    [SerializeField] private Animator triggerAnimator;
    private bool pantallaPrincipal;

    [SerializeField] private GameObject gameObjectQuestion;
    [SerializeField] private GameObject lifes; // Nota: cambio de "Lifes" a "lifes" para seguir las convenciones de nomenclatura
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject triggerQuestion;

    void Start()
    {
        movingObjects = FindObjectsOfType<Moving>();
        foreach (Moving movingObject in movingObjects)
        {
            movingObject.StopMovement();
        }
        moveTappy.StopMovement();
        triggerAnimator.SetTrigger(animationThink);
        gameObjectQuestion.SetActive(false);
        lifes.SetActive(false);
        triggerQuestion.SetActive(false);
        pantallaPrincipal = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (pantallaPrincipal)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PicarPantalla();
                pantallaPrincipal = false;
            }
        }
    }

    private void PicarPantalla()
    {
        Debug.Log("PicarPantalla called"); // Log para depuración
        moveTappy.ActiveMovement();
        foreach (Moving movingObject in movingObjects)
        {
            movingObject.ActiveMovement();
        }
        triggerAnimator.SetTrigger(animationRun);
        gameObjectQuestion.SetActive(true);
        lifes.SetActive(true);
        menu.SetActive(false);
        triggerQuestion.SetActive(true);
        camara.SetPlayOn(true);
 
    }
}
