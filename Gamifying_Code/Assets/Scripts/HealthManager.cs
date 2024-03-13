using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update

    //Set variables for player Max health and Current Health
    public float PlayerMaxHealth;
    public float PlayerCurrentHealth;

    //Set variables for Enemy Max health and Current Health
    public float EnemyMaxHealth;
    public float EnemyCurrentHealth;

    
    public Slider PlayerSlider;
    public Slider EnemySlider;

    private Image PlayerIcon;
    private Image EnemyIcon;

    public int enemyDeathCounter;
    public GameObject enemyspawnlocation;
    public GameObject Enemy;
    


    

    void Start()
    {
        // Find the Slider that Controlls the Players Health
        PlayerSlider = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
        PlayerCurrentHealth = EnemyMaxHealth;
        PlayerSlider.maxValue = EnemyMaxHealth;

        // Find the Slider that Controlls the Enemy Health
        EnemySlider = GameObject.FindGameObjectWithTag("EnemyHealthBar").GetComponent<Slider>();

        // Set up refences to the icons of the healh bars so we can change them later
        PlayerIcon = GameObject.FindGameObjectWithTag("PlayerIcon").GetComponent<Image>();
        EnemyIcon = GameObject.FindGameObjectWithTag("EnemyIcon").GetComponent<Image>();


        //Sets the current health to max health at the start.
        EnemyCurrentHealth = EnemyMaxHealth;

        //Sets the max value of the slider to the Players Max Health
        EnemySlider.maxValue = EnemyMaxHealth;

        enemyspawnlocation = GameObject.FindGameObjectWithTag("EnemySpawnLocation");
    }

    // Update is called once per frame
    void Update()
    {
        //Update the health every frame(might change this later)
        EnemySlider.value = EnemyCurrentHealth;
        PlayerSlider.value = PlayerCurrentHealth;
        Enemy = enemyspawnlocation.GetComponent<EnemySpawnLocation>().currentEnemy;

        if(EnemyCurrentHealth <= 0)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(Enemy);
            enemyspawnlocation.GetComponent<EnemySpawnLocation>().EnemyPicker = Random.Range(1,3);
            EnemyCurrentHealth = 100;

        }

    }

    //Call this Function to do damage to the Enemy
    public void DamageEnemy(float DamageAmount)
    {
        EnemyCurrentHealth -= DamageAmount;
    }
    //Call this Function to do damage to the player.
    public void PlayerEnemy(float DamageAmount)
    {
        PlayerCurrentHealth -= DamageAmount;
    }
    public void killPlayer()
    {
        PlayerCurrentHealth = -5;
    }
}
