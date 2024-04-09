using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public float PlayerLAttack = 10;
    public float PlayerMAttack = 15;
    public float PlayerHAttack = 20;
    public float EnemyAttack = 20;

    public float FailedLAttack = 2;
    public float FailedMAttack = 3;
    public float FailedHAttack = 5;

    public GameObject StateManager;
    public GameObject QuizManager;

    public GameObject HealthManager;
    public GameObject Player;
    public GameObject attacksapwner;

    public void Start()
    {
        StateManager = GameObject.FindGameObjectWithTag("StateManager");
        HealthManager = GameObject.FindGameObjectWithTag("HealthManager");
        QuizManager = GameObject.FindGameObjectWithTag("QuizManager");
        Player = GameObject.FindGameObjectWithTag("Player");
        attacksapwner = GameObject.FindGameObjectWithTag("AttackSpawner");
    }

    public void ApplyLAttack()  
    {
        float hitChance = 0.8f; // 80% chance to land.
        QuizManager quizManagerScript = QuizManager.GetComponent<QuizManager>(); // Get the QuizManager script.
        
        if (Random.value <= hitChance)
        {
            HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerLAttack);
           // Player.GetComponent<Animator>().SetTrigger("LightAttack");
            quizManagerScript.IncrementAttacksLanded();
            quizManagerScript.attackLLanded();
            attacksapwner.GetComponent<AttacKSpawner>().SpawnAndMoveObject2();
            StateManager.GetComponent<StateManagerScript>().enemyattack = true;

        }
        else
        {
            HealthManager.GetComponent<HealthManager>().PlayerEnemy(FailedLAttack);
            quizManagerScript.IncrementAttacksFailed();
            quizManagerScript.attackLFailed();
            Player.GetComponent<Animator>().SetTrigger("FailedAttack");
            StateManager.GetComponent<StateManagerScript>().enemyattack = true;

        }

        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        quizManagerScript.isAttackPressed = true;
    }

    public void ApplyMAttack()
    {
        float hitChance = 0.6f; // 60% chance to land.
        QuizManager quizManagerScript = QuizManager.GetComponent<QuizManager>(); // Get the QuizManager script.
        
        if (Random.value <= hitChance)
        {
            HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerMAttack);
            Player.GetComponent<Animator>().SetTrigger("MediumAttack");
            quizManagerScript.IncrementAttacksLanded();
            quizManagerScript.attackMLanded();
            attacksapwner.GetComponent<AttacKSpawner>().SpawnAndMoveObject();
            StateManager.GetComponent<StateManagerScript>().enemyattack = true;

        }
        else
        {
            HealthManager.GetComponent<HealthManager>().PlayerEnemy(FailedMAttack);
            quizManagerScript.IncrementAttacksFailed();
            quizManagerScript.attackMFailed();
            Player.GetComponent<Animator>().SetTrigger("FailedAttack");
            StateManager.GetComponent<StateManagerScript>().enemyattack = true;


        }

        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        quizManagerScript.isAttackPressed = true;
    }

    public void ApplyHAttack()
    {
        float hitChance = 0.4f; // 40% chance to land.
        QuizManager quizManagerScript = QuizManager.GetComponent<QuizManager>(); // Get the QuizManager script.
        
        if (Random.value <= hitChance)
        {
            HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerHAttack);
            Player.GetComponent<Animator>().SetTrigger("HeavyAttack");
            quizManagerScript.IncrementAttacksLanded();
            quizManagerScript.attackHLanded();
            attacksapwner.GetComponent<AttacKSpawner>().SpawnAndMoveObject3();
            StateManager.GetComponent<StateManagerScript>().enemyattack = true;


        }
        else
        {
            HealthManager.GetComponent<HealthManager>().PlayerEnemy(FailedHAttack);
            quizManagerScript.IncrementAttacksFailed();
            quizManagerScript.attackHFailed();
            Player.GetComponent<Animator>().SetTrigger("FailedAttack");
            StateManager.GetComponent<StateManagerScript>().enemyattack = true;

        }

        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        quizManagerScript.isAttackPressed = true;
    }
}
