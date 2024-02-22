using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Extensions;

public class AttackManager : MonoBehaviour
{
    public float PlayerLAttack = 10;
    public float PlayerMAttack = 15;
    public float PlayerHAttack = 20;
    public float EnemyAttack = 20;
    public GameObject StateManager;

    public GameObject HealthManager;
    public GameObject Player;

    public void Start()
    {
        StateManager = GameObject.FindGameObjectWithTag("StateManager");
        HealthManager = GameObject.FindGameObjectWithTag("HealthManager");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ApplyLAttack()  
    {
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerLAttack);
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        Player.GetComponent<Animator>().SetTrigger("LightAttack");

    }

    public void ApplyMAttack()
    {
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerMAttack);
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        Player.GetComponent<Animator>().SetTrigger("MediumAttack");
    }

    public void ApplyHAttack()
    {
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerHAttack);
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
        Player.GetComponent<Animator>().SetTrigger("HeavyAttack");
    }
    //GC
}
