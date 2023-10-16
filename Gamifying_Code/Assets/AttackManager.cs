using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public float PlayerLAttack = 10;
    public float PlayerMAttack = 15;
    public float PlayerHAttack = 20;
    private GameObject StateManager;

    public GameObject HealthManger;

    public void Start()
    {
       StateManager = GameObject.FindGameObjectWithTag("StateManager");
    }

    public void ApplyLAttack()
    {

        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true; 
    }
    public void ApplyMAttack()
    {
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
    }
    public void ApplyHAttack()
    {
        StateManager.GetComponent<StateManagerScript>().PlayerAttackPressed = true;
    }

}
