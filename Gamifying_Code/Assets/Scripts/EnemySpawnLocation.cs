using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnLocation : MonoBehaviour
{
    public int EnemyPicker;
    public GameObject enemySpawnLocation;
  
    public GameObject ComputerEnemy;
    public GameObject BlockEnemy;
    public GameObject BlockEnemyOrange;
    public GameObject currentEnemy;

    // Start is called before the first frame update
    void Start()
    {

        EnemyPicker = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
  

        currentEnemy = GameObject.FindGameObjectWithTag("Enemy");
        if(EnemyPicker == 1)
        {
            Instantiate(ComputerEnemy, enemySpawnLocation.transform.position, Quaternion.identity);
            EnemyPicker = 0;
        }
        else if(EnemyPicker == 2)
        {
            Instantiate(BlockEnemy, enemySpawnLocation.transform.position, Quaternion.identity
                );
            EnemyPicker = 0;
        }
        else if(EnemyPicker == 3)
        {
            Instantiate(BlockEnemyOrange, enemySpawnLocation.transform.position, Quaternion.identity
                );
            EnemyPicker = 0;
        }
    }
}