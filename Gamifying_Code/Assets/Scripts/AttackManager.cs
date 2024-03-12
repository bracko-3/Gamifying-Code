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

    public void Start()
    {
        StateManager = GameObject.FindGameObjectWithTag("StateManager");
        HealthManager = GameObject.FindGameObjectWithTag("HealthManager");
        QuizManager = GameObject.FindGameObjectWithTag("QuizManager");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ApplyLAttack()  
    {
        float hitChance = 0.8f; // 80% chance to land.
        if (Random.value <= hitChance)
        {
            HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerLAttack);
            Player.GetComponent<Animator>().SetTrigger("LightAttack");
            Debug.Log("Attack successful!");
        }
        else
        {
            HealthManager.GetComponent<HealthManager>().PlayerEnemy(FailedLAttack);
            Debug.Log("Attack missed!");
        }
        
        // Attack is pressed no matter what.
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        QuizManager.GetComponent<QuizManager>().isAttackPressed = true;
    }

    public void ApplyMAttack()
    {
        float hitChance = 0.6f; // 60% chance to land.
        if (Random.value <= hitChance)
        {
            HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerMAttack);
            Player.GetComponent<Animator>().SetTrigger("MediumAttack");
        }
        else
        {
            HealthManager.GetComponent<HealthManager>().PlayerEnemy(FailedMAttack);
            Debug.Log("Attack missed!");
        }
        
        // Attack is pressed no matter what.
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        QuizManager.GetComponent<QuizManager>().isAttackPressed = true;
    }

    public void ApplyHAttack()
    {
        float hitChance = 0.4f; // 40% chance to land.
        if (Random.value <= hitChance)
        {
            HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerHAttack);
            Player.GetComponent<Animator>().SetTrigger("HeavyAttack");
            Debug.Log("Attack successful!");
        }
        else
        {
            HealthManager.GetComponent<HealthManager>().PlayerEnemy(FailedHAttack);
            Debug.Log("Attack missed!");
        }
        
        // Attack is pressed no matter what.
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        QuizManager.GetComponent<QuizManager>().isAttackPressed = true;
    }
}
