using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManagerScript : MonoBehaviour
{

    private enum GameState
    {
        Menu,
        PlayerQuestion,
        PlayerAttack,
        EnemyAttack,
        NextEnemy,
        PlayerDeath,

    }
    private GameObject QuestionsUI;
    private GameObject quizManager;
    [SerializeField]
    private GameObject AttackPopUp;

    public GameObject[] AnswerBtns;
    public GameObject[] AttackBtns;

    [SerializeField]
    private GameState _currentState;

    public bool CorrectAnswerPressed;
    public bool PlayerAttackPressed;
    public bool startQuestion = false;
    public bool popupShowing = false;

    // Start is called before the first frame update
    void Start()
    { 
        _currentState = GameState.PlayerQuestion;
        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
        AnswerBtns = GameObject.FindGameObjectsWithTag("Answer Button");
    }

    public IEnumerator popupDelay()
    {
        yield return new WaitForSeconds(2);
        AttackPopUp.SetActive(true);
        popupShowing = true;
    }

    void delayAttackPressed()
    {
        _currentState = GameState.PlayerQuestion;
        AttackPopUp.SetActive(false);
        popupShowing = false;
        startQuestion = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CorrectAnswerPressed == true)
        {
            _currentState = GameState.PlayerAttack;
            StartCoroutine(popupDelay());
        }
        if(PlayerAttackPressed == true)
        {
            PlayerAttackPressed = false;
            Invoke("delayAttackPressed", 2.0f);
        }

        switch (_currentState)
        {
            case GameState.PlayerQuestion:
                foreach (GameObject AttackButton in AttackBtns)
                {
                    AttackButton.GetComponent<Button>().interactable = false;
                }
                break;

            case GameState.PlayerAttack:
                foreach (GameObject Answerbutton in AnswerBtns)
                {
                    Answerbutton.GetComponent<Button>().interactable = false;
                }
                foreach (GameObject AttackButton in AttackBtns)
                {
                    AttackButton.GetComponent<Button>().interactable = true;
                }
                CorrectAnswerPressed = false;
                break;

            case GameState.EnemyAttack:
                Debug.Log("EnemyTurnTo attack");
                PlayerAttackPressed = false;
                break;

            case GameState.NextEnemy:
                Debug.Log("ChooseNext Enemy");
                foreach (GameObject Answerbutton in AnswerBtns)
                {
                    Answerbutton.GetComponent<Button>().interactable = false;
                }

                break;

            case GameState.PlayerDeath:
                Debug.Log("PlayeDied");
                break;

            default:
                break;
        }//Gc
    }
}
