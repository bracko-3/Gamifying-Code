using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnLocation : MonoBehaviour
{
    public int EnemyPicker;
    public GameObject enemySpawnLocation;
  
    public GameObject ComputerEnemy;
    public GameObject BlockEnemy;

    // Start is called before the first frame update
    void Start()
    {

        EnemyPicker = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyPicker== 1)
        {
            Instantiate(ComputerEnemy, enemySpawnLocation.transform);
            EnemyPicker ++ ;
            EnemyPicker ++ ;
        }
        else if(EnemyPicker == 2)
        {
            Instantiate(BlockEnemy, enemySpawnLocation.transform);
        }
    }
}
