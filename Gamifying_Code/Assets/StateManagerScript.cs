using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject AnswerBtn1;
    public GameObject AnswerBtn2;
    public GameObject AnswerBtn3;
    public GameObject AnswerBtn4;

    [SerializeField]
    private GameState _currentState;



    // Start is called before the first frame update
    void Start()
    {
        quizManager = GameObject.FindGameObjectWithTag("QuizManager");
        _currentState = GameState.PlayerQuestion;
    }

    // Update is called once per frame
    void Update()
    {

        switch (_currentState)
        {
            case GameState.PlayerQuestion:
                Debug.Log("Player choose an Answer");
      
                break;

            case GameState.PlayerAttack:
                Debug.Log("Player choose an attack");
               
                break;

            case GameState.EnemyAttack:
                Debug.Log("EnemyTurnTo attack");
                break;

            case GameState.NextEnemy:
                Debug.Log("ChooseNext Enemy");
                break;

            case GameState.PlayerDeath:
                Debug.Log("PlayeDied");
                break;

            default:
                break;
        }
    }
}
