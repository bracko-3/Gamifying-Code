using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    public bool isAttackPressed = false;

    //Used for telling if the popup shows up, so we can reset the questions and answers to blank.
    private bool isPopupShowing;

    //declare at class level
    private FirebaseAPI.User userInfo;

    //unique identifier for firebase
    private string userID;
    private string gameCode; // TODO: Need to make this based on input at beginning of the game.
    private string userName; // TODO: Need to make this based on input at beginning of the game.
    public int questionAttempts = 0;
    public int questionNumber = 0;
    public int attacksLanded = 0;
    public int attacksFailed = 0;
    public int gamifyScore = 0;

    // for gamify score
    public bool answerCorrectOnFirstTry = false;

    public int typeOfAttack = 0;

    // for Your Scores Leaderboard
    public Text YS_username;
    public Text YS_gamifyscore;
    public Text YS_totalquestions;
    public Text YS_correctquestions;
    public Text YS_attackslanded;
    public Text YS_quizpercentage;
    private int quizPercent;

    private void Start()
    {
        stateManager = GameObject.FindGameObjectWithTag("StateManager");
        userID = SystemInfo.deviceUniqueIdentifier;
        typeQuestion();

        // firebase variables
        gameCode = "TSTCD1"; // TODO: Need to make this based on input at beginning of the game.
        userName = "bracko3"; // TODO: Need to make this based on input at beginning of the game.

        // create new user with no info when game starts.
        userInfo = new FirebaseAPI.User(userName, 0, 0, 0, 0, 0);

        // Send new user to firebase
        FirebaseAPI.PostUser(userInfo, gameCode, userID);
    }

    private void Update()
    {
        //always checking to see if the popup is showing, to remove the questions and answers at the same time.
        isPopupShowing = stateManager.GetComponent<StateManagerScript>().popupShowing;
        
        //if it has been pressed, type 1 question,. then turn it back to false so it doesnt go through all the questions.
        if (isAttackPressed == true)
        {
            StartCoroutine(typeQuestionDelay());
            isAttackPressed = false;
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

        Debug.Log($"Question Attempts = {questionAttempts}");

        if(questionAttempts == 1)
        {
            userInfo.totalQuestions += 1;
            userInfo.questionsCorrect += 1;
            answerCorrectOnFirstTry = true;

            //reset for next question 
            questionAttempts = 0;
        }
        else
        {
            userInfo.totalQuestions += 1;

            //reset for next question 
            questionAttempts = 0;
        }
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
            currentQuestionInt = UnityEngine.Random.Range(0, QnA.Count);

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

        quizPercent = (int)Math.Round((float)userInfo.questionsCorrect / userInfo.totalQuestions * 100);

        // assigning user information to the Your Scores Section
        YS_username.text = "User: " + userName;
        YS_gamifyscore.text = "Gamify: " + userInfo.gamifyScore;
        YS_totalquestions.text = "Total Questions: " + userInfo.totalQuestions;
        YS_correctquestions.text = "Correct Questions: " + userInfo.questionsCorrect;
        YS_attackslanded.text = "Attacks Landed: " + userInfo.attacksLanded;
        YS_quizpercentage.text = "Quiz Percentage: " + quizPercent + "%";
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

    public void UpdatePlayerInfo() 
    {
        FirebaseAPI.PostUser(userInfo, gameCode, userID);
    }

    public void IncrementAttacksLanded() 
    {
        userInfo.attacksLanded += 1;
    }

    public void IncrementAttacksFailed() 
    {
        userInfo.attacksFailed += 1;
    }

    // Small attack landed and failed
    public void attackLLanded ()
    {
        if (answerCorrectOnFirstTry = true)
        {
            userInfo.gamifyScore += 70;
            answerCorrectOnFirstTry = false;
            UpdatePlayerInfo();
        }
        else
        {
            userInfo.gamifyScore += 45;
            UpdatePlayerInfo();
        }
    }

    public void attackLFailed ()
    {
        if (answerCorrectOnFirstTry = true)
        {
            userInfo.gamifyScore += 40;
            answerCorrectOnFirstTry = false;
            UpdatePlayerInfo();
        }
        else
        {
            userInfo.gamifyScore += 15;
            UpdatePlayerInfo();
        }
    }

    // Medium attack landed and failed
    public void attackMLanded ()
    {
        if (answerCorrectOnFirstTry = true)
        {
            userInfo.gamifyScore += 85;
            answerCorrectOnFirstTry = false;
            UpdatePlayerInfo();
        }
        else
        {
            userInfo.gamifyScore += 60;
            UpdatePlayerInfo();
        }
    }

    public void attackMFailed ()
    {
        if (answerCorrectOnFirstTry = true)
        {
            userInfo.gamifyScore += 35;
            answerCorrectOnFirstTry = false;
            UpdatePlayerInfo();
        }
        else
        {
            userInfo.gamifyScore += 10;
            UpdatePlayerInfo();
        }
    }

    // High attack landed and failed
    public void attackHLanded ()
    {
        if (answerCorrectOnFirstTry = true)
        {
            userInfo.gamifyScore += 100;
            answerCorrectOnFirstTry = false;
            UpdatePlayerInfo();
        }
        else
        {
            userInfo.gamifyScore += 75;
            UpdatePlayerInfo();
        }
    }

    public void attackHFailed ()
    {
        if (answerCorrectOnFirstTry = true)
        {
            userInfo.gamifyScore += 25;
            answerCorrectOnFirstTry = false;
            UpdatePlayerInfo();
        }
        else
        {
            userInfo.gamifyScore += 0;
            UpdatePlayerInfo();
        }
    }
}