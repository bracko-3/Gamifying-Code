using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject collisionParticleEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Spawn collision particle effect
            Instantiate(collisionParticleEffect,transform.position, Quaternion.identity);

            // Destroy the enemy object
   

            // Destroy the bullet object
            Destroy(gameObject);
        }
    }
}
