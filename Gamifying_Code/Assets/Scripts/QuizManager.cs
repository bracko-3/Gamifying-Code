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

    //For answers being written out
    private string currentAnswerText = "";
    public float answerDelay = 0.05f;

    //What gets shown for the question on the game
    public Text QuestionTxt;

    //For type writing part of quiz
    public float questionDelay = 0.1f;
    private string currentText = "";
    private string questionToTypeWriter;

    //Used for telling if the attack has been pressed, so we can start a new question.
    private bool isAttackPressed;

    //Used for telling if the popup shows up, so we can reset the questions and answers to blank.
    private bool isPopupShowing;

    //To show what question you're on
    private int questionNumber = 0;

    private void Start()
    {
        stateManager = GameObject.FindGameObjectWithTag("StateManager");
        typeQuestion();
    }

    private void Update()
    {
        //always checking to see if the attack has been pressed
        isAttackPressed = stateManager.GetComponent<StateManagerScript>().PlayerAttackPressed;

        //always checking to see if the popup is showing, to remove the questions and answers at the same time.
        isPopupShowing = stateManager.GetComponent<StateManagerScript>().popupShowing;
        
        //if it has been pressed, type 1 question,. then turn it back to false so it doesnt go through all the questions.
        if (isAttackPressed == true)
        {
            isAttackPressed = false;
            StartCoroutine(typeQuestionDelay());
        }

        //if popup shows up, make the question and answers go away
        if (isPopupShowing == true)
        {
            //Reset the question and answers to blank while waiting for next question to type out all the way.
            resetQuestionAndAnswers();
            stateManager.GetComponent<StateManagerScript>().popupShowing = false;
        }
    }

    public IEnumerator typeQuestionDelay()
    {
        yield return new WaitForSeconds(2);
        typeQuestion();
    }


    public void correct()
    {
        QnA.RemoveAt(currentQuestionInt);
        stateManager.GetComponent<StateManagerScript>().CorrectAnswerPressed = true;
    }

    public IEnumerator setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            //Type writter for answers
            for (int x = 0; x <= QnA[currentQuestionInt].Answers[i].Length; x++)
            {
                currentAnswerText = QnA[currentQuestionInt].Answers[i].Substring(0, x);
                options[i].transform.GetChild(0).GetComponent<Text>().text = currentAnswerText;
                yield return new WaitForSeconds(answerDelay);
            }

            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;

            if (QnA[currentQuestionInt].CorrectAnswers == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }

        //Makes buttons clickable after they have all typed out. They are set to false everytime you get the answer correct.
        foreach (GameObject option in options)
        {
            option.GetComponent<Button>().interactable = true;
        }
    }

    public void resetQuestionAndAnswers()
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
            questionNumber += 1;
            Debug.Log("Question number " + questionNumber);
            questionToTypeWriter = generateQuestion();
            StartCoroutine(ShowQuestion());
        }
        else
        {
            Debug.Log("Out of Questions");
            endGame();
        }
    }

    public void endGame() {
        stateManager.GetComponent<StateManagerScript>().endScreen = true;
    }

    IEnumerator ShowQuestion()
    {
        for (int i = 0; i <= questionToTypeWriter.Length; i++)
        {
            currentText = questionToTypeWriter.Substring(0, i);
            QuestionTxt.text = currentText;
            yield return new WaitForSeconds(questionDelay);
        }
        StartCoroutine(setAnswers());
    }
}
