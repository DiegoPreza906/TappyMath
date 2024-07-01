using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public QuestionManager questionManager;

    //Vida del jugador
    public PlayerHealth playerHealth;

    public void TriggerQuestion()
    {
        Question randomQuestion = GenerateRandomQuestion();
        questionManager.ShowQuestion(randomQuestion.questionText, randomQuestion.answers, randomQuestion.correctAnswer);
    }

    private Question GenerateRandomQuestion()
    {
        int operationType = Random.Range(1, 4); // 1: Suma, 2: Resta, 3: Multiplicación, 4: División
        int num1 = Random.Range(1, 21); // Generar un número aleatorio entre 1 y 20
        int num2 = Random.Range(1, 21); // Generar un número aleatorio entre 1 y 20

        string questionText = "";
        string correctAnswer = "";
        string[] answers = new string[4];

        switch (operationType)
        {
            case 1: // Suma
                questionText = $"What is {num1} + {num2}?";
                correctAnswer = (num1 + num2).ToString();
                break;
            case 2: // Resta
                questionText = $"What is {num1} - {num2}?";
                correctAnswer = (num1 - num2).ToString();
                break;
            case 3: // Multiplicación
                questionText = $"What is {num1} x {num2}?";
                correctAnswer = (num1 * num2).ToString();
                break;
            case 4: // División
                while (num2 == 0 || num1 % num2 != 0) // Asegurar una división entera
                {
                    num2 = Random.Range(1, 21);
                }
                questionText = $"What is {num1} / {num2}?";
                correctAnswer = (num1 / num2).ToString();
                break;
        }

        // Generar respuestas aleatorias
        HashSet<string> answerSet = new HashSet<string> { correctAnswer };
        for (int i = 0; i < answers.Length; i++)
        {
            if (i == 0)
            {
                answers[i] = correctAnswer;
            }
            else
            {
                int incorrectAnswer;
                do
                {
                    incorrectAnswer = Random.Range(1, 41); // Generar respuestas incorrectas
                } while (!answerSet.Add(incorrectAnswer.ToString()));
                answers[i] = incorrectAnswer.ToString();
            }
        }

        // Mezclar las respuestas
        for (int i = 0; i < answers.Length; i++)
        {
            int randomIndex = Random.Range(0, answers.Length);
            string temp = answers[i];
            answers[i] = answers[randomIndex];
            answers[randomIndex] = temp;
        }

        return new Question { questionText = questionText, answers = answers, correctAnswer = correctAnswer };
    }

    public void CorrectAnswer()
    {
        Time.timeScale = 1;
        FindObjectOfType<QuestionTrigger>().IniciarCorrutina();
        Debug.Log("Continuar el juego");

    }

    public void WrongAnswer()
    {
        
        Time.timeScale = 1;
        playerHealth.WrongAnswer();
        FindObjectOfType<QuestionTrigger>().IniciarCorrutina();
        Debug.Log("Pierdes una vida");

    }

}
