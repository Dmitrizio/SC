using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    private Finish _finish;
    private Animator animator;
    [SerializeField] private AudioSource activateSound;
    private void Start()
    {
        animator = GetComponent<Animator>();
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
    }
     public void activateLeverArm()
    {
        activateSound.Play();
        animator.SetTrigger("Activate");
        _finish.Activate();
    }
}
