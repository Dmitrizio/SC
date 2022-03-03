using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private AttackController _attackController;
    [SerializeField]private float damage = 20f;
    [SerializeField] private AudioSource enemyHitSound;
    

    private void Start()
    {
        _attackController = transform.root.GetComponent<AttackController>();
        
    }
    


    private void OnTriggerEnter2D(Collider2D other)
    {

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
       
      
       
      

        if (enemyHealth != null && _attackController.IsAttack)
        {

            enemyHealth.reduceHealth(damage);
            
            enemyHitSound.Play();
        }
    }
   

}

