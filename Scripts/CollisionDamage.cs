using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private float damage = 10f;







    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if(other.gameObject.CompareTag("Player"))
        {
            playerHealth.reduceHealth(damage);
        }
    }
}
