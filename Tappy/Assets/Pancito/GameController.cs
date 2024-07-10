using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public QuestionManager questionManager;
    public PlayerH playerHealth;
    [SerializeField] private Animator triggerAnimator;
    [SerializeField] private string animationTriggerName = "Correr"; // Nombre del trigger de la animación

    private int correctAnswersCount = 0;
    private int currentLevel = 1;

    void Start()
    {
        // Asegúrate de que QuestionTrigger se encuentra en la escena en el momento del inicio
        QuestionTrigger questionTrigger = FindObjectOfType<QuestionTrigger>();
        if (questionTrigger != null)
        {
            Debug.Log("QuestionTrigger encontrado al iniciar.");
        }
        else
        {
            Debug.Log("No se encontró QuestionTrigger al iniciar.");
        }

        StartNewLevel(); // Comenzar el primer nivel al iniciar el juego
    }

    public void TriggerQuestion()
    {
        Question randomQuestion = GenerateRandomQuestion();
        questionManager.ShowQuestion(randomQuestion.questionText, randomQuestion.answers, randomQuestion.correctAnswer);
    }

private Question GenerateRandomQuestion()
{
    int num1 = GetRandomNumberForLevel(currentLevel);
    int num2 = GetRandomNumberForLevel(currentLevel);

    string questionText = "";
    string correctAnswer = "";
    string[] answers = new string[4];

    switch (currentLevel)
    {
        case 1: // Nivel Primaria (Suma y Resta)
            int operationType1 = UnityEngine.Random.Range(1, 3); // 1: Suma, 2: Resta
            if (operationType1 == 1)
            {
                questionText = $"¿Cuánto es {num1} + {num2}?";
                correctAnswer = (num1 + num2).ToString();
            }
            else
            {
                questionText = $"¿Cuánto es {num1} - {num2}?";
                correctAnswer = (num1 - num2).ToString();
            }
            break;
        case 2: // Nivel Secundaria (Suma, Resta, Multiplicación)
            int operationType2 = UnityEngine.Random.Range(1, 4); // 1: Suma, 2: Resta, 3: Multiplicación
            if (operationType2 == 1)
            {
                questionText = $"¿Cuánto es {num1} + {num2}?";
                correctAnswer = (num1 + num2).ToString();
            }
            else if (operationType2 == 2)
            {
                questionText = $"¿Cuánto es {num1} - {num2}?";
                correctAnswer = (num1 - num2).ToString();
            }
            else
            {
                questionText = $"¿Cuánto es {num1} x {num2}?";
                correctAnswer = (num1 * num2).ToString();
            }
            break;
        case 3: // Nivel Secundaria con Multiplicaciones
            num1 = UnityEngine.Random.Range(10, 100); // Limitar num1 para multiplicaciones (2 dígitos)
            num2 = 1; // Segundo número siempre será 1 para facilitar la operación
            questionText = $"¿Cuánto es {num1} x {num2}?";
            correctAnswer = (num1 * num2).ToString();
            break;
        case 4: // Nivel Preparatoria con Divisiones
            num1 = UnityEngine.Random.Range(10, 100); // Limitar num1 para divisiones (2 dígitos)
            int divisor = 1; // Divisor siempre será 1 para facilitar la operación
            while (num1 % divisor != 0) // Asegurar división entera
            {
                num1 = UnityEngine.Random.Range(10, 100); // Limitar num1 para divisiones (2 dígitos)
            }
            questionText = $"¿Cuánto es {num1} / {divisor}?";
            correctAnswer = (num1 / divisor).ToString();
            break;
        case 5: // Nivel Secundaria Avanzada
            int operationType5 = UnityEngine.Random.Range(1, 5); // 1: Suma, 2: Resta, 3: Multiplicación, 4: División
            num1 = UnityEngine.Random.Range(10, 100); // Limitar num1 para todas las operaciones avanzadas (2 dígitos)
            num2 = UnityEngine.Random.Range(1, 100); // Limitar num2 para todas las operaciones avanzadas
            if (operationType5 == 1)
            {
                questionText = $"¿Cuánto es {num1} + {num2}?";
                correctAnswer = (num1 + num2).ToString();
            }
            else if (operationType5 == 2)
            {
                questionText = $"¿Cuánto es {num1} - {num2}?";
                correctAnswer = (num1 - num2).ToString();
            }
            else if (operationType5 == 3)
            {
                questionText = $"¿Cuánto es {num1} x {num2}?";
                correctAnswer = (num1 * num2).ToString();
            }
            else
            {
                int divisor5 = 1; // Divisor siempre será 1 para facilitar la operación
                while (num1 % divisor5 != 0) // Asegurar división entera
                {
                    num1 = UnityEngine.Random.Range(10, 100); // Limitar num1 para divisiones (2 dígitos)
                }
                questionText = $"¿Cuánto es {num1} / {divisor5}?";
                correctAnswer = (num1 / divisor5).ToString();
            }
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
                incorrectAnswer = GetIncorrectAnswerForLevel(currentLevel); // Generar respuestas incorrectas
            } while (!answerSet.Add(incorrectAnswer.ToString()));
            answers[i] = incorrectAnswer.ToString();
        }
    }

    // Mezclar las respuestas
    for (int i = 0; i < answers.Length; i++)
    {
        int randomIndex = UnityEngine.Random.Range(0, answers.Length);
        string temp = answers[i];
        answers[i] = answers[randomIndex];
        answers[randomIndex] = temp;
    }

    return new Question { questionText = questionText, answers = answers, correctAnswer = correctAnswer };
}

    private int GetRandomNumberForLevel(int level)
    {
        int maxNumber = 20; // Por defecto para niveles iniciales
        switch (level)
        {
            case 2:
                maxNumber = 50; // Números más grandes para nivel secundaria
                break;
            case 5:
                maxNumber = 100; // Números más grandes para nivel secundaria avanzada
                break;
        }
        return UnityEngine.Random.Range(1, maxNumber + 1);
    }

    private int GetDivisorForLevel(int level)
    {
        int maxDivisor = 10; // Divisores más pequeños para niveles iniciales
        switch (level)
        {
            case 4:
                maxDivisor = 20; // Divisores más grandes para nivel preparatoria
                break;
            case 5:
                maxDivisor = 50; // Divisores más grandes para nivel secundaria avanzada
                break;
        }
        return UnityEngine.Random.Range(1, maxDivisor + 1);
    }

    private int GetIncorrectAnswerForLevel(int level)
    {
        int maxIncorrectAnswer = 40; // Respuestas incorrectas más grandes para niveles superiores
        switch (level)
        {
            case 1:
                maxIncorrectAnswer = 20; // Respuestas incorrectas hasta 20 para niveles iniciales
                break;
            case 2:
                maxIncorrectAnswer = 50; // Respuestas incorrectas hasta 50 para nivel secundaria
                break;
            case 3:
                maxIncorrectAnswer = 100; // Respuestas incorrectas hasta 100 para nivel secundaria con multiplicaciones
                break;
        }
        return UnityEngine.Random.Range(1, maxIncorrectAnswer + 1);
    }

    private void StartNewLevel()
    {
        if (correctAnswersCount >= 5)
        {
            currentLevel++;
            correctAnswersCount = 0;
            Debug.Log($"Comenzando nivel {currentLevel}");
        }
    }

    public void CorrectAnswer()
    {
        correctAnswersCount++;
        StartNewLevel();

        QuestionTrigger questionTrigger = FindObjectOfType<QuestionTrigger>();
        if (questionTrigger != null)
        {
            triggerAnimator.SetTrigger(animationTriggerName);
            questionTrigger.IniciarCorrutina();
            Debug.Log("Continuar el juego");
        }
        else
        {
            Debug.LogError("No se encontró QuestionTrigger en CorrectAnswer.");
        }
    }

    public void WrongAnswer()
    {
        // Verificar que playerHealth no es nulo
        if (playerHealth != null)
        {
            playerHealth.WrongAnswer();
            Debug.Log("Pierdes una vida");
        }
        else
        {
            Debug.LogError("playerHealth es nulo.");
        }
        QuestionTrigger questionTrigger = FindObjectOfType<QuestionTrigger>();

        if (questionTrigger != null)
        {
            triggerAnimator.SetTrigger(animationTriggerName);
            questionTrigger.IniciarCorrutina();
        }
        else
        {
            Debug.LogError("No se encontró QuestionTrigger en WrongAnswer.");
        }
    }
}