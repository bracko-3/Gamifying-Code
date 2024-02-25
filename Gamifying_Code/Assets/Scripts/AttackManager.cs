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
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerLAttack);
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        QuizManager.GetComponent<QuizManager>().isAttackPressed = true;
        Player.GetComponent<Animator>().SetTrigger("LightAttack");

    }

    public void ApplyMAttack()
    {
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerMAttack);
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        QuizManager.GetComponent<QuizManager>().isAttackPressed = true;
        Player.GetComponent<Animator>().SetTrigger("MediumAttack");
    }

    public void ApplyHAttack()
    {
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerHAttack);
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        QuizManager.GetComponent<QuizManager>().isAttackPressed = true;
        Player.GetComponent<Animator>().SetTrigger("HeavyAttack");
    }
    //GC
}
