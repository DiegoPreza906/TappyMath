using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    private string correctAnswer;
    private GameController gameController; // Referencia al controlador del juego

    void Start()
    {
        gameObject.SetActive(false); // Ocultar el Canvas al inicio
        gameController = FindObjectOfType<GameController>(); // Buscar el GameController en la escena
    }

    public void ShowQuestion(string question, string[] answers, string correctAnswer)
    {
        gameObject.SetActive(true); // Mostrar el Canvas
        this.correctAnswer = correctAnswer;
        questionText.text = question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < answers.Length)
            {
                answerButtons[i].gameObject.SetActive(true); // Mostrar solo los botones necesarios
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[i];
                answerButtons[i].onClick.RemoveAllListeners();
                string answer = answers[i]; // Capturar la respuesta en una variable local para la lambda
                answerButtons[i].onClick.AddListener(() => CheckAnswer(answer));
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false); // Ocultar botones innecesarios
            }
        }
    }

    private void CheckAnswer(string answer)
    {
        if (answer == correctAnswer)
        {
            Debug.Log("Correct Answer");
            gameController.CorrectAnswer(); // Llamar al método para respuesta correcta
        }
        else
        {
            Debug.Log("Wrong Answer");
            gameController.WrongAnswer(); // Llamar al método para respuesta incorrecta
        }
        gameObject.SetActive(false); // Ocultar el Canvas
    }
}
