using UnityEngine;
using System.Collections;

public class CoroutineTest : MonoBehaviour
{
    [SerializeField] private float waitTime = 10.0f;

    void Start()
    {
        StartCoroutine(TestCoroutine());
    }

    private IEnumerator TestCoroutine()
    {
        Debug.Log("Corrutina iniciada, esperando " + waitTime + " segundos.");
        yield return new WaitForSecondsRealtime(waitTime);
        Debug.Log("Tiempo de espera completado.");
    }
}
