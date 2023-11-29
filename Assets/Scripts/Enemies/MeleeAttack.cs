using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator animator;

    public Transform AttackPoint;
    public float attackRange = 0.5f;

    public LayerMask playerLayer;

    public int attackDamage = 5;
    public float attackSpeed = 2f;
    private float nextAttackTime = 0f;
    private GameObject PlayerCharacter;
    public float attackDistance = 2f;
    public float attackHitTime = 0.5f;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {

        float distance = Vector2.Distance(transform.position, PlayerCharacter.transform.position);

        if (distance < attackDistance)
        {
            if (Time.time >= nextAttackTime)
            {
                StartCoroutine (Attack());
                nextAttackTime = Time.time + 1f / attackSpeed;
                Debug.Log("Attack");
            }
        }
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(attackHitTime);
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("Hit " + player.name);

            player.GetComponent<PlayerHP>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
