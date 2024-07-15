using UnityEngine;

public class AumentarVelocidad : MonoBehaviour
{
    private Moving[] movingObjects;
    [SerializeField] public StopBananas banana;
    [SerializeField] public Animator characterAnimator; // Referencia al Animator del personaje
    private float currentRunSpeed;

    private float velocidadIncremento = 0.025f; // Incremento de velocidad de 0.25x

    private void Start()
    {
        movingObjects = FindObjectsOfType<Moving>();
    }

    public void Velocidad()
    {
        foreach (Moving movingObject in movingObjects)
        {
            movingObject.Aumentar();
        }
        banana.Aumentar();

        // Aumentar la velocidad de la animación de correr
        currentRunSpeed = characterAnimator.GetFloat("RunSpead");
        float nuevaVelocidad = currentRunSpeed + velocidadIncremento;
        characterAnimator.SetFloat("RunSpead", nuevaVelocidad);

        Debug.Log("Velocidad de animación de correr aumentada a: " + nuevaVelocidad);
    }
}
