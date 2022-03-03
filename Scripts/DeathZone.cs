using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private float damage = 2000f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if(playerHealth != null)
        {
            playerHealth.reduceHealth(damage);
        }
        if(enemyHealth != null)
        {
            enemyHealth.reduceHealth(damage);
        }
    }
}
