using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float timeToDamage = 1f;
    private float _timeBetweenDamage;
    private bool isDamage = true;
    [SerializeField] Animator animator;
    private GameObject _enemyWeapon;
   







    private void Start()
    {
        _timeBetweenDamage = timeToDamage;
        _enemyWeapon = GameObject.Find("EnemyAttack");
        
        





    }

    private void Update()
    {
        if (!isDamage)
        {
            _timeBetweenDamage -= Time.deltaTime;
            if (_timeBetweenDamage <= 0f)
            {
                enemyAttack();
                _timeBetweenDamage = timeToDamage;
            }
        }

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null && isDamage)
        {
            animator.SetTrigger("Attack");
            playerHealth.reduceHealth(damage);
            isDamage = false;
            _enemyWeapon.GetComponent<BoxCollider2D>().enabled = false;

        }
 
    
    }

    public void enemyAttack()
    {
        isDamage = true;
        _enemyWeapon.GetComponent<BoxCollider2D>().enabled = true;
    }
}


