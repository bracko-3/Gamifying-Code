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
    public GameObject EndGamePopup; 

    [SerializeField]
    private GameState _currentState;

    public bool CorrectAnswerPressed;
    public bool PlayerAttackPressed;
    public bool popupShowing = false;
    public bool playerdeath = false;



    // Start is called before the first frame update
    void Start()
    { 
        _currentState = GameState.PlayerQuestion;
        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
        AnswerBtns = GameObject.FindGameObjectsWithTag("Answer Button");
        //AttackPopUp = GameObject.FindGameObjectWithTag("Attackpopup");
        EndGamePopup = GameObject.FindGameObjectWithTag("EndGamePopup");
        
    }

    public IEnumerator popupDelay()
    {
        yield return new WaitForSeconds(2);
        AttackPopUp.SetActive(true);
        popupShowing = true;
    }

    // Update is called once per frame
    void Update()
    {   if (playerdeath == true ){
        _currentState = GameState.PlayerDeath;
    }
        if(CorrectAnswerPressed == true)
        {
            _currentState = GameState.PlayerAttack;
            StartCoroutine(popupDelay());
        }
        if(PlayerAttackPressed == true)
        {
            _currentState = GameState.PlayerQuestion;
        }

        switch (_currentState)
        {
            case GameState.PlayerQuestion:

                AttackPopUp.SetActive(false);
                EndGamePopup.SetActive(false);
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
                PlayerAttackPressed = false;
                AttackPopUp.SetActive(false);
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
                EndGamePopup.SetActive(true);
                break;

            default:
                break;
        }//Gc
    }
}
