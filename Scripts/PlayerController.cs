using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedX = 3f;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource jumpSound;
    private Rigidbody2D _rb;
    private float _horizontal;
    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFacingRight = true;
    private Finish _finish;
    private bool _isFinish = false;
    private bool _isLever = false;
    private LeverArm _leverArm;
    [SerializeField] private float chargeForce = 5000f;
    private bool chargeLock = false;
    private float pushPowerX = 200f;
    
    
    const float speedXMultiplier = 50f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        _leverArm = FindObjectOfType<LeverArm>();
      
    }
    private void Update()
    {
        animator.SetBool("isGround", _isGround);
        _horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("speedX", Mathf.Abs(_horizontal));
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _isJump = true;
            jumpSound.Play();


        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isFinish)
            {
                _finish.finishLevel();
            }
            if(_isLever)
            {
                _leverArm.activateLeverArm();
            }
        }
        Charge();
        
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * speedX * speedXMultiplier * Time.fixedDeltaTime, _rb.velocity.y);
        if (_isJump)
        {
            _rb.AddForce(new Vector2(0f, 500f));
            _isGround = false;
            _isJump = false;
            animator.SetTrigger("isJumping");
         
        }
        
        

        if(_horizontal > 0f && !_isFacingRight)
        {
            Flip();
        }
        else if(_horizontal < 0f && _isFacingRight)
        {
            Flip();
            
        }
        
        void Flip()
        {
            _isFacingRight = !_isFacingRight;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Field"))
            {
            _isGround = true;
            
          
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        LeverArm leverArmTemp = other.GetComponent<LeverArm>();
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Yes");
            _isFinish = true;
        }
        if (leverArmTemp != null)
        {
            _isLever = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        LeverArm leverArmTemp = other.GetComponent<LeverArm>();
        if (other.CompareTag("Finish"))
        {
            Debug.Log("No");
            _isFinish = false;
        }
        if (leverArmTemp != null)
        {
            _isLever = false;
        }
    }

    private void Charge()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !chargeLock)
        {
            chargeLock = true;
            
            Invoke("UnlockCharge", 2f);
            
            
            _rb.velocity = new Vector2(0, 0);
            if(!_isFacingRight)
            {
                _rb.AddForce(Vector2.left * chargeForce);
            }
            else
            {
                _rb.AddForce(Vector2.right * chargeForce);
            }
        }
        
    }
    private void UnlockCharge()
    {
        chargeLock = false;
        
    }
    


}
