using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KnightAI : MonoBehaviour
{
    public Animator animator = null;
    public Rigidbody2D rb;
    private GameObject PlayerCharacter;
    public DirectionFinder Directions = null;
    public bool hasAnimation = false;

    public float horizontal = 0f;
    public float Speed = 5f;
    public float jumpHeight = 5f;
    public bool jump = false;
    bool FaceR = true;

    public bool playerInRange = false;
    public bool playerTooClose = false;
    public float tooClose = 1f;
    private float timer;
    private float timer1;
    private float randomDir;
    private float randomInter = 2f;
    public float generalCD = 2f;
    public float detectionRange = 10f;
    public int dontRunAway = 1;

    Vector2 movement;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;



    void Awake()
    {
        timer = randomInter;
        timer1 = generalCD;

        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (!playerInRange)
        {
            horizontal = randomDir;
        }
        else
        {
            PlayerChase();
        }

        if (jump)
        {
            if (hasAnimation)
            {
                animator.SetTrigger("Jump");
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);

            jump = false;
        }

        flip();
        if (hasAnimation)
        {
            animator.SetFloat("Moving", Mathf.Abs(horizontal));
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, groundLayer);
    }


    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        timer1 -= Time.deltaTime;

        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

        if (timer1 < 0)
        {
            if (IsWalled())
            {
                jump = true;
                timer1 = generalCD;
                //Debug.Log("Jump");
            }

            float distance = Vector2.Distance(transform.position, PlayerCharacter.transform.position);
            if (distance < detectionRange)
            {
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }

            float distanceTooClose = Vector2.Distance(transform.position, PlayerCharacter.transform.position);
            if (distanceTooClose < tooClose)
            {
                playerTooClose = true;
            }
            else
            {
                playerTooClose = false;
            }
        }

        if (timer < 0 && !playerInRange)
        {
            timer = randomInter;

            System.Random random = new System.Random();
            randomDir = random.Next(-1, 2);
            //Debug.Log(randomDir);
        }
    }

    void PlayerChase()
    {
        if (!playerTooClose)
        {
            timer1 -= Time.deltaTime;

            horizontal = Directions.Direction * dontRunAway;
        }
        else
        {
            horizontal = 0;
        }

        if (timer1 < 0)
        {
            jump = Directions.Above;
            timer1 = generalCD;
        }
    }

    

    void flip()
    {
        if (FaceR && horizontal < 0f || !FaceR && horizontal > 0f)
        {
            FaceR = !FaceR;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, tooClose);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(wallCheck.position, 0.2f);
    }
}
