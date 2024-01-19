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
    [SerializeField]
    private GameObject quizManager;
    [SerializeField]
    private GameObject HealthManager;
    [SerializeField]
    private GameObject AttackManager;
    [SerializeField]
    private GameObject AttackPopUp;

    public GameObject[] AnswerBtns;
  

    [SerializeField]
    private GameState _currentState;

    public bool CorrectAnswerPressed;
    public bool PlayerAttackPressed;
    public bool popupShowing = false;

    // Start is called before the first frame update
    void Start()
    { 
        _currentState = GameState.PlayerQuestion;
        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
        AnswerBtns = GameObject.FindGameObjectsWithTag("Answer Button");
        HealthManager = GameObject.FindGameObjectWithTag("HealthManager");
        AttackManager = GameObject.FindGameObjectWithTag("AttackManager");
        AttackPopUp = GameObject.FindGameObjectWithTag("AttackPopUp");
    }

    public IEnumerator popupDelay()
    {
        yield return new WaitForSeconds(2);
        AttackPopUp.SetActive(true);
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
            _currentState = GameState.EnemyAttack;
        }
        if(HealthManager.GetComponent<HealthManager>().PlayerCurrentHealth <= 0)
        {
            _currentState = GameState.PlayerDeath;
        }
        switch (_currentState)
        {
            case GameState.PlayerQuestion:

                AttackPopUp.SetActive(false);
                PlayerAttackPressed = false;
                break;

            case GameState.PlayerAttack:
                foreach (GameObject Answerbutton in AnswerBtns)
                {
                    Answerbutton.GetComponent<Button>().interactable = false;
                }
                CorrectAnswerPressed = false;
                break;

            case GameState.EnemyAttack:
                Debug.Log("EnemyTurnTo attack");
                
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

            default:
                break;
        }//Gc
    }
}
