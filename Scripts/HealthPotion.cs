using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
   [SerializeField] private int Heal = 20;
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            PlayerHealth healthBar = other.GetComponent<PlayerHealth>();
            if(playerHealth.currentHealth < playerHealth.health)
            {
                playerHealth.currentHealth += Heal;
                healthBar.initHealth();
                Destroy(gameObject);
            }
            
            
            if(playerHealth.currentHealth > playerHealth.health)
            {
                healthBar.initHealth();
                playerHealth.currentHealth = playerHealth.health;
            }
           
            
        }
    }

}
