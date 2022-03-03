using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] public float health = 100f;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private AudioSource takeHit;
    public float currentHealth;
    


    
    private void Start()
    {
        currentHealth = health;
        initHealth();
        animator = GetComponent<Animator>();
    }
   
    public void reduceHealth(float damage)
    {
        currentHealth -= damage;
        initHealth();
        animator.SetTrigger("Damage");
        takeHit.Play();
        if (currentHealth <= 0)
        {
            Die();
        }
       
    }

    public void initHealth()
    {
        healthBar.value = currentHealth / health;
    }
    private void Die()
    {
        animator.SetBool("Dead", true);

        gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
