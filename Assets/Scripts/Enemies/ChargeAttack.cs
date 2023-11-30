using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject PlayerCharacter;
    private SpriteRenderer sprite;
    public LayerMask playerLayer;
    public Transform AttackPoint;

    public int attackDamage = 2;
    public float attackRange = 2f;
    public float chargeDistance = 25f;
    public float detectionRange = 10f;
    public float chargeUp = 1f;
    public float chargeDelay = 0.5f;
    public float chargeCD = 5f;
    public float chargeDuration = 0.05f;
    public bool disableMovement = false;
    public int chargeTimes = 5;

    private float timer;
    private Vector3 direction;
    private bool charging = false;



    void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        timer = chargeCD;
    }

    void FixedUpdate()
    {
        direction = PlayerCharacter.transform.position - transform.position;

        float distance = Vector2.Distance(transform.position, PlayerCharacter.transform.position);

        if (!charging)
        {
            timer -= Time.deltaTime;
        }

        if (distance < detectionRange)
        {
            if (timer < 0 && !charging)
            {
                StartCoroutine(chargeAttack());
                timer = chargeCD;
            }
        }
    }


    IEnumerator chargeAttack()
    {
        charging = true;
        disableMovement = true;

        for (int i = 0; i < 4; i++)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(chargeDelay);
            sprite.color = Color.white;
            yield return new WaitForSeconds(chargeDelay);
        }
        sprite.color = Color.red;

        yield return new WaitForSeconds(chargeUp);
        for (int i = 0; i < chargeTimes; i++)
        {
            rb.velocity = new Vector2(direction.x, direction.y).normalized * chargeDistance;
            yield return new WaitForSeconds(chargeDuration);
            rb.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(chargeDelay);
        }
      
        sprite.color = Color.white;
        charging = false;
        disableMovement = false;
        Debug.Log("Dash");
    }

    void attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("Hit " + player.name);

            player.GetComponent<PlayerHP>().TakeDamage(attackDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

}
