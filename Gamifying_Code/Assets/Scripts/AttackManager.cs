using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public float PlayerLAttack = 10;
    public float PlayerMAttack = 15;
    public float PlayerHAttack = 20;
    private GameObject StateManager;

    public GameObject HealthManager;

    public void Start()
    {
       StateManager = GameObject.FindGameObjectWithTag("StateManager");
    
    }

    void delayAttackPressed()
    {
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
    }

    public void ApplyLAttack()
    {
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerLAttack);
        Invoke("delayAttackPressed", 3.0f);
    }

    public void ApplyMAttack()
    {
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerMAttack);
        Invoke("delayAttackPressed", 3.0f);
    }

    public void ApplyHAttack()
    {
        HealthManager.GetComponent<HealthManager>().DamageEnemy(PlayerHAttack);
        Invoke("delayAttackPressed", 3.0f);
    }
    //GC
}
