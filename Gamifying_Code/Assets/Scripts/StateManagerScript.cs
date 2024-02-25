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
        EndGame
    }
    private GameObject QuestionsUI;
    [SerializeField]
    private GameObject quizManager;
    [SerializeField]
    private GameObject HealthManager;
    [SerializeField]
    private GameObject AttackManager;
    [SerializeField]
    private GameObject AttackPopUp;

    public GameObject[] AnswerBtns;

    private GameObject PlayerHealthBar;
    private GameObject EnemyHealthBar;
    private GameObject PlayerModel;
    private GameObject EnemyModel;
    private GameObject QuestionUI;


    [SerializeField]
    private GameState _currentState;

    public bool CorrectAnswerPressed;
    public bool PlayerAttackPressed;
    public bool popupShowing = false;
    public bool endScreen = false;

    // Start is called before the first frame update
    void Start()
    { 
        _currentState = GameState.PlayerQuestion;
        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
        AnswerBtns = GameObject.FindGameObjectsWithTag("Answer Button");
        HealthManager = GameObject.FindGameObjectWithTag("HealthManager");
        AttackManager = GameObject.FindGameObjectWithTag("AttackManager");
        AttackPopUp = GameObject.FindGameObjectWithTag("AttackPopUp");

        // For end screen - to make not visiable
        PlayerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar");
        EnemyHealthBar = GameObject.FindGameObjectWithTag("EnemyHealthBar");
        PlayerModel = GameObject.FindGameObjectWithTag("Player");
        EnemyModel = GameObject.FindGameObjectWithTag("Enemy");
        QuestionUI = GameObject.FindGameObjectWithTag("Question Background");
    }

    public IEnumerator popupDelay()
    {
        yield return new WaitForSeconds(2);
        AttackPopUp.SetActive(true);
        QuestionUI.SetActive(false);
        popupShowing = true;
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
            _currentState = GameState.PlayerQuestion;
            PlayerAttackPressed = false;
        }

        if(HealthManager.GetComponent<HealthManager>().PlayerCurrentHealth <= 0)
        {
            _currentState = GameState.PlayerDeath;
        }

        // end screen
        if(endScreen == true)
        {
            _currentState = GameState.EndGame;
        }
        switch (_currentState)
        {
            case GameState.PlayerQuestion:
                QuestionUI.SetActive(true);
                AttackPopUp.SetActive(false);
                Debug.Log("Game State: Player Question");

                break;

            case GameState.PlayerAttack:
                Debug.Log("GameState: Player attack");
                foreach (GameObject Answerbutton in AnswerBtns)
                {
                    Answerbutton.GetComponent<Button>().interactable = false;
                }
                CorrectAnswerPressed = false;

                break;

            case GameState.EnemyAttack:
                Debug.Log("Game State: Enemy Attack");
                
                AttackPopUp.SetActive(false);
                HealthManager.GetComponent<HealthManager>().PlayerCurrentHealth -= AttackManager.GetComponent<AttackManager>().EnemyAttack;
                _currentState = GameState.PlayerQuestion;
                
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
            
            case GameState.EndGame:
                PlayerHealthBar.SetActive(false);
                EnemyHealthBar.SetActive(false);
                PlayerModel.SetActive(false);
                EnemyModel.SetActive(false);
                AttackPopUp.SetActive(false);
                QuestionUI.SetActive(false);

                break;

            default:
                break;
        }//Gc
    }
}
