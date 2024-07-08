using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public TextMeshProUGUI timerText; // Temporizador en el Canvas
    public GameObject questionCanvas; // Canvas que contiene la pregunta y el temporizador
    private string correctAnswer;
    private GameController gameController;
    private Coroutine timerCoroutine;
    private Moving[] movingObjects; // Array de referencias a los objetos en movimiento
    public MoveTappy moveTappy;
    void Start()
    {
        questionCanvas.SetActive(false);
        gameController = FindObjectOfType<GameController>();
        movingObjects = FindObjectsOfType<Moving>(); // Buscar todos los objetos en movimiento en la escena
    }

    public void ShowQuestion(string question, string[] answers, string correctAnswer)
    {
        questionCanvas.SetActive(true);
        this.correctAnswer = correctAnswer;
        questionText.text = question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < answers.Length)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[i];
                answerButtons[i].onClick.RemoveAllListeners();
                string answer = answers[i];
                answerButtons[i].onClick.AddListener(() => { StopTimer(); CheckAnswer(answer); });
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }

        // Detener todos los objetos en movimiento
        foreach (Moving movingObject in movingObjects)
        {
            movingObject.StopMovement();
        }
        moveTappy.StopMovement();
        // Iniciar el temporizador
        timerCoroutine = StartCoroutine(TimerCoroutine(10f));
    }

    private void CheckAnswer(string answer)
    {
        if (answer == correctAnswer)
        {
            Debug.Log("Correct Answer");
            // Reanudar el movimiento de todos los objetos
            foreach (Moving movingObject in movingObjects)
            {
                movingObject.ActiveMovement();
                
            }
            moveTappy.ActiveMovement();
            gameController.CorrectAnswer();
        }
        else
        {
            Debug.Log("Wrong Answer");
            // Reanudar el movimiento de todos los objetos
            foreach (Moving movingObject in movingObjects)
            {
                movingObject.ActiveMovement();
            }
            moveTappy.ActiveMovement();
            gameController.WrongAnswer();
        }
        questionCanvas.SetActive(false);
    }

    private IEnumerator TimerCoroutine(float timeLimit)
    {
        float remainingTime = timeLimit;
        while (remainingTime > 0)
        {
            timerText.text = remainingTime.ToString("F2"); // Mostrar tiempo restante con dos decimales
            yield return new WaitForSeconds(1f);
            remainingTime -= 1f;
        }
        Debug.Log("Time is up!");
        CheckAnswer(""); // Pasar una respuesta vacía para indicar que el tiempo se agotó
    }

    private void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }
}
