using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public QuestionManager questionManager;
    public PlayerH playerHealth;
    [SerializeField] private Animator triggerAnimator;
    [SerializeField] private string animationTriggerName = "Correr"; // Nombre del trigger de la animación
    private int currentLevel = 1;
    private int correctAnswers = 0;

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
            Debug.LogError("No se encontró QuestionTrigger al iniciar.");
        }
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
            case 2: // Nivel Secundaria (Suma, Resta)
                int operationType2 = UnityEngine.Random.Range(1, 3); // 1: Suma, 2: Resta
                if (operationType2 == 1)
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
            case 3: // Nivel Secundaria con Multiplicaciones
                num1 = UnityEngine.Random.Range(10, 100); // Limitar num1 para multiplicaciones (2 dígitos)
                num2 = UnityEngine.Random.Range(1, 10); // Limitar num2 para multiplicaciones (1 dígito)
                questionText = $"¿Cuánto es {num1} x {num2}?";
                correctAnswer = (num1 * num2).ToString();
                break;
            case 4: // Nivel Preparatoria con Divisiones
                num1 = UnityEngine.Random.Range(10, 100); // Limitar num1 para divisiones (2 dígitos)
                num2 = UnityEngine.Random.Range(1, 10); // Limitar num2 para divisiones (1 dígito)
                while (num1 % num2 != 0) // Asegurar división entera
                {
                    num1 = UnityEngine.Random.Range(10, 100);
                }
                questionText = $"¿Cuánto es {num1} / {num2}?";
                correctAnswer = (num1 / num2).ToString();
                break;
            case 5: // Nivel Secundaria Avanzada
                int operationType5 = UnityEngine.Random.Range(1, 5); // 1: Suma, 2: Resta, 3: Multiplicación, 4: División
                num1 = UnityEngine.Random.Range(10, 100); // Limitar num1 para todas las operaciones avanzadas (2 dígitos)
                num2 = UnityEngine.Random.Range(1, 10); // Limitar num2 para todas las operaciones avanzadas (1 dígito para multiplicación y división)
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
                    while (num1 % num2 != 0) // Asegurar división entera
                    {
                        num1 = UnityEngine.Random.Range(10, 100);
                    }
                    questionText = $"¿Cuánto es {num1} / {num2}?";
                    correctAnswer = (num1 / num2).ToString();
                }
                break;
        }

        // Generar respuestas similares
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
                    incorrectAnswer = GenerateSimilarAnswer(int.Parse(correctAnswer)); // Generar respuestas similares
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
        switch (level)
        {
            case 1: // Nivel Primaria
                return UnityEngine.Random.Range(1, 21);
            case 2: // Nivel Secundaria
                return UnityEngine.Random.Range(10, 51);
            case 3: // Nivel Secundaria con Multiplicaciones
                return UnityEngine.Random.Range(10, 100);
            case 4: // Nivel Preparatoria con Divisiones
                return UnityEngine.Random.Range(10, 100);
            case 5: // Nivel Secundaria Avanzada
                return UnityEngine.Random.Range(10, 100);
            default:
                return 0;
        }
    }

    private int GenerateSimilarAnswer(int correctAnswer)
    {
        int offset = UnityEngine.Random.Range(-5, 6); // Generar un offset pequeño para respuestas similares
        return correctAnswer + offset;
    }

    public void CorrectAnswer()
    {
        correctAnswers++;
        if (correctAnswers >= 5)
        {
            currentLevel++;
            correctAnswers = 0;
            if (currentLevel > 5) currentLevel = 5;
        }

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
        if (correctAnswers >= 5)
        {
            currentLevel = currentLevel - 1;
        }
        correctAnswers = 0;

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