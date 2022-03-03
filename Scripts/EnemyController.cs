using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float walkDistance = 12f;
    [SerializeField] float patrolSpeed = 2f;
    [SerializeField] float timeToWait = 5f;
    [SerializeField] float chaseTime = 5f;
    [SerializeField] float chasingSpeed = 4f;
    [SerializeField] Animator animator;
    
    
   

    private Rigidbody2D _rb;
    private Vector2 _leftBorderPosition;
    private Vector2 _rightBorderPosition;
    private bool _isFacingRight = true;
    private bool _isWait = false;
    private float _waitTime;
    private float _chaseTime;
    private bool _isChasingPlayer = false;
    private float _walkSpeed;
    private Transform _playerTransform;
    private Vector2 nextPoint;
    private bool collidedWithPlayer;
    
    

    public bool IsFacingRight
    {
        get => _isFacingRight;
    }
   

    public void startChasingPlayer()
    {
        _isChasingPlayer = true;
        _chaseTime = chaseTime;
        _walkSpeed = chasingSpeed;
       
    }
    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _leftBorderPosition = transform.position;
        _rightBorderPosition = _leftBorderPosition + Vector2.right * walkDistance;
        _waitTime = timeToWait;
        _chaseTime = chaseTime;
        _walkSpeed = patrolSpeed;
        
    }
    private void Update()
    {
        if (_isChasingPlayer)
        {
            startChasingTimer();
        }

        if(_isWait && !_isChasingPlayer)
        {
            startWaitTimer();
            
        }
        

        if(shouldWait())
        {
            _isWait = true;
            


        }
        


    }
    private void FixedUpdate()
    {
        nextPoint = Vector2.right * _walkSpeed * Time.fixedDeltaTime;
        if (_isChasingPlayer && collidedWithPlayer)
        {
            
            return;
           

        }
       
        

        if(_isChasingPlayer)
        {
            chasePlayer();
            animator.SetBool("Run", true);
            animator.SetBool("Stay", false);

        }

        if (!_isWait && !_isChasingPlayer)
        {
            Patrol();
            animator.SetBool("Run", true);
            animator.SetBool("Stay", false);
        }

       
    }
    private void Patrol()
    {
        if (!_isFacingRight)
        {
            nextPoint.x *= -1;
        }
        _rb.MovePosition((Vector2)transform.position + nextPoint);
       

    }
    private void chasePlayer()
    {
        float distance = distanceToPlayer();
        if (distance < 0)
        {
            nextPoint.x *= -1;
        }
        if (distance > 0.2f && !_isFacingRight)
        {
           
            Flip();
        }
        else if (distance < 0.2f && _isFacingRight)
        {
            
            Flip();
        }
        
        _rb.MovePosition((Vector2)transform.position + nextPoint);
        

    }
    private float distanceToPlayer()
    {
        return _playerTransform.position.x - transform.position.x;
    }
    private void startWaitTimer()
    {
        if (_isWait)
        {
            _waitTime -= Time.deltaTime;
            animator.SetBool("Run", false);
            animator.SetBool("Stay", true);
            if (_waitTime <= 0f)
            {
                _isWait = false;
                _waitTime = timeToWait;
                
                Flip();

            }
        }
    }
    private void startChasingTimer()
    {
        _chaseTime -= Time.deltaTime;
        if(_chaseTime <0f)
        {
            _isChasingPlayer = false;
            _chaseTime = chaseTime;
            _walkSpeed = patrolSpeed;
            
        }
    }
    private bool shouldWait()
    {
        bool isOutOfRightBorder = _isFacingRight && transform.position.x >= _rightBorderPosition.x;
        bool isOutOfLeftBorder = !_isFacingRight && transform.position.x <= _leftBorderPosition.x;

        return isOutOfLeftBorder || isOutOfRightBorder;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBorderPosition, _rightBorderPosition);
    }
    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(player != null)
        {
            collidedWithPlayer = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            collidedWithPlayer = false;
        }
    }
   




    }
        
    

    
