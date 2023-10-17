using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public GameObject stateManager;

    //current question in the list of questions and the current question selected.
    [SerializeField]
    private int currentQuestionInt;
    private string currentQuestion;
        
    //What gets shown for the question on the game
    public Text QuestionTxt;

    //For type writing part of quiz
    public float delay = 0.1f;
    private string currentText = "";
    private string questionToTypeWriter;

    private void Start()
    {
        stateManager = GameObject.FindGameObjectWithTag("StateManager");
        generateQuestionAndAnswers();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestionInt);
        stateManager.GetComponent<StateManagerScript>().CorrectAnswerPressed = true;

        Invoke(nameof(generateQuestionAndAnswers), 5);
        
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestionInt].Answers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;

            if (QnA[currentQuestionInt].CorrectAnswers == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public string generateQuestion()
    {
            currentQuestionInt = Random.Range(0, QnA.Count);

            currentQuestion = QnA[currentQuestionInt].Question;

            return currentQuestion;
    }

    public void generateQuestionAndAnswers()
    {
        if (QnA.Count > 0)
        {
            questionToTypeWriter = generateQuestion();
            StartCoroutine(ShowText());
            //Invoke(nameof(setAnswers), 4); use this for waiting to set answers in the future
        }
        else
        {
            Debug.Log("Out of Questions");
        }
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= questionToTypeWriter.Length; i++)
        {
            currentText = questionToTypeWriter.Substring(0, i);
            QuestionTxt.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        setAnswers();
    }
}
