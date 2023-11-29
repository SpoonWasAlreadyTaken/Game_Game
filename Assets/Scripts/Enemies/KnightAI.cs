using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KnightAI : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    private GameObject PlayerCharacter;
    public DirectionFinder Directions;

    public float horizontal = 0f;
    public float Speed = 5f;
    public float jumpHeight = 5f;
    public bool jump = false;
    bool FaceR = true;

    public bool playerInRange = false;
    private float timer;
    private float timer1;
    private float randomDir;
    private float randomInter = 2f;
    public float generalCD = 2f;
    public float detectionRange = 10f;

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
            animator.SetTrigger("Jump");

            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);

            jump = false;
        }

        flip();
        animator.SetFloat("Moving", Mathf.Abs(horizontal));
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
                Debug.Log("Jump");
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
        }

        if (timer < 0 && !playerInRange)
        {
            timer = randomInter;

            System.Random random = new System.Random();
            randomDir = random.Next(-1, 2);
            Debug.Log(randomDir);
        }
    }

    void PlayerChase()
    {
        timer1 -= Time.deltaTime;

        horizontal = Directions.Direction;

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
}
