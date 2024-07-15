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

    void Update()
    {
        if(move)
        {
            // Calcula la distancia recorrida en este frame
            float distanceTraveled = environmentSpeed *Time.deltaTime;

            // Actualiza la distancia total recorrida
            totalDistance += distanceTraveled;

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
