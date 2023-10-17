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
  

    [SerializeField]
    private GameState _currentState;

    public bool CorrectAnswerPressed;
    public bool PlayerAttackPressed;



    // Start is called before the first frame update
    void Start()
    { 
        _currentState = GameState.PlayerQuestion;
        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
        AnswerBtns = GameObject.FindGameObjectsWithTag("Answer Button");
        //AttackPopUp = GameObject.FindGameObjectWithTag("Attackpopup");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CorrectAnswerPressed == true)
        {
            PlayerAttackPressed = false;
            _currentState = GameState.PlayerAttack;
        }
        if(PlayerAttackPressed == true)
        {
            _currentState = GameState.PlayerQuestion;
        }

        switch (_currentState)
        {
            case GameState.PlayerQuestion:
                foreach(GameObject Answerbutton in AnswerBtns)
                {
                    Answerbutton.GetComponent<Button>().interactable = true;
                }

                AttackPopUp.SetActive(false);
                break;

            case GameState.PlayerAttack:
                foreach (GameObject Answerbutton in AnswerBtns)
                {
                    Answerbutton.GetComponent<Button>().interactable = false;
                }
                AttackPopUp.SetActive(true);
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
                break;

            default:
                break;
        }//Gc
    }
}
