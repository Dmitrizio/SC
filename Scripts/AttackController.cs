using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource attackSound;
    private bool _isAttack;
    [SerializeField]private float timeBetweenAttack = 1f;
    private float _timeBA;
    public bool IsAttack { get => _isAttack; }
    private GameObject _weapon;
    private bool readyAttack;


    private void Start()
    {
        _weapon = GameObject.Find("Weapon");
        _weapon.GetComponent<BoxCollider2D>().enabled = false;
        _timeBA = timeBetweenAttack;
        
        
    }
    
    public void finishAttack()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            _weapon.GetComponent<BoxCollider2D>().enabled = false;

        }
        _isAttack = false;
    }

    private void Update()
    {
        Attack();
        
    }
    private void Attack()
    {
        if(!readyAttack)
        {
              _timeBA -= Time.deltaTime;
                if (_timeBA <= 0f)
                {
                    readyAttack = true;
                _timeBA = timeBetweenAttack;
                }
            
        }
        if (Input.GetMouseButtonDown(0) && readyAttack)
        {
            _weapon.GetComponent<BoxCollider2D>().enabled = true;
            _isAttack = true;
            readyAttack = false;
            animator.SetTrigger("Attack");
            attackSound.Play();
        }
    }
}
