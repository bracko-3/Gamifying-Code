using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyAttack : MonoBehaviour
{
    public GameObject EnemyAttack1;
    public GameObject EnemyAttack2;
    public GameObject EnemyAttack3;

   public void spawnattack1() 
    {
        Instantiate(EnemyAttack1, transform.position, Quaternion.identity);

    }
    public void spawnattack2()
    {
        Instantiate(EnemyAttack2, transform.position, Quaternion.identity);

    }
    public void spawnattack3()
    {
        Instantiate(EnemyAttack3, transform.position, Quaternion.identity);

    }



}
