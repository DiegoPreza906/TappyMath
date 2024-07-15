using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float environmentSpeed = 1; // Velocidad del entorno en unidades por segundo
    private float totalDistance = 0; // Distancia total recorrida
    public TextMeshProUGUI distanceText; // Referencia al objeto TextMeshPro
    private bool move = true;
    [SerializeField] public AumentarVelocidad veloz;
    private float nextSpeedIncreaseDistance = 10.0f;

    void Update()
    {
        if(move)
        {
            // Calcula la distancia recorrida en este frame
            float distanceTraveled = environmentSpeed *Time.deltaTime;

            // Actualiza la distancia total recorrida
            totalDistance += distanceTraveled;

            if (totalDistance >= nextSpeedIncreaseDistance)
            {
                Debug.LogWarning("POCO A POCO");
                veloz.Velocidad();
                nextSpeedIncreaseDistance += 10.0f; // Actualiza para el próximo incremento
            }

            distanceText.text = "" + totalDistance.ToString("F2") + "m";

            // Para propósitos de depuración, imprime la distancia total recorrida en la consola
        }

    }
    public void NoseMueve()
    {
        Debug.Log("Hola ya no me muevo");
        move = false;
    }

    public void SiseMueve()
    {
        move = true;
    }

    public float RegresarScore()
    {
        return totalDistance;
    }
}
