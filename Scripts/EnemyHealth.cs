using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private Animator animator;
    private UnityEngine.Object explosion;
    
   
    


    private void Start()
    {
        animator = GetComponent<Animator>();
        explosion = Resources.Load("Explosion");
        
       
    }

    public void reduceHealth (float damage)
    {
        health -= damage;
        animator.SetTrigger("Damage");
        
        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        GameObject explosionRes = (GameObject)Instantiate(explosion);
        explosionRes.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        Destroy(gameObject);
        
    }
    


}
