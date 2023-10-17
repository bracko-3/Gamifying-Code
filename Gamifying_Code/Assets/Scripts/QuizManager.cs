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

    private bool isAttackPressed;

    private void Start()
    {
        stateManager = GameObject.FindGameObjectWithTag("StateManager");
        typeQuestion();
    }

    private void Update()
    {
        isAttackPressed = stateManager.GetComponent<StateManagerScript>().PlayerAttackPressed;
        if(isAttackPressed == true)
        {
            typeQuestion();
            stateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = false;
        }
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestionInt);
        stateManager.GetComponent<StateManagerScript>().CorrectAnswerPressed = true;

        //Reset Answers to blank, waiting for next question to type out all the way.
        resetQuestionAndAnswers();
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

    void resetQuestionAndAnswers()
    {
        QuestionTxt.text = "";
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetChild(0).GetComponent<Text>().text = " ";
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
        }
    }

    public string generateQuestion()
    {
            currentQuestionInt = Random.Range(0, QnA.Count);

            currentQuestion = QnA[currentQuestionInt].Question;

            return currentQuestion;
    }

    public void typeQuestion()
    {
        if (QnA.Count > 0)
        {
            questionToTypeWriter = generateQuestion();
            StartCoroutine(ShowText());
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
