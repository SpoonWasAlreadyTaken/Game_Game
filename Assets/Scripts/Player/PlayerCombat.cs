using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform AttackPoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayer;

    public int attackDamage = 5;
    public float attackSpeed = 2f;
    private float nextAttackTime = 0f;

    [SerializeField] private AudioSource attackSound;

    public void IncreaseDamage(int damageBuff)
    {
        attackDamage += damageBuff;
    }

    public void IncreaseAttack(int attackBuff)
    {
        attackSpeed += attackBuff;
    }
    public void IncreaseRange(float rangeBuff)
    {
        attackRange += rangeBuff;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackSpeed;
                attackSound.Play();
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);

            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
