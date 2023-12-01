using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackController : MonoBehaviour
{
    private GameObject PlayerCharacter;
    public Transform parent;

    FireballAttack kingGooseFire;
    public GameObject hellSpawner;

    public float attackSpeed = 5f;
    private float timer;
    public float attackDistance = 15f;
    private float randomAttack;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        timer = attackSpeed;
        kingGooseFire = GameObject.FindGameObjectWithTag("GooseKing").GetComponent<FireballAttack>();
    }



    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, PlayerCharacter.transform.position);

        if (distance < attackDistance)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                System.Random random = new System.Random();
                randomAttack = random.Next(1, 4);

                switch (randomAttack)
                {
                    case 1:
                        Debug.Log("Attack1");
                        kingGooseFire.GetComponent<FireballAttack>().FireBallAttackStart();
                        timer = attackSpeed;
                        break;
                    case 2:
                        Debug.Log("Attack2");
                        hellSpawner.GetComponent<FireballHellSpawner>().spinSpeedGrow = 0.2f;
                        Instantiate(hellSpawner, transform.position, transform.rotation, parent);
                        timer = attackSpeed;
                        timer += 5;
                        break;
                    case 3:
                        Debug.Log("Attack3");
                        hellSpawner.GetComponent<FireballHellSpawner>().spinSpeedGrow = 0.1f;
                        Instantiate(hellSpawner, transform.position, transform.rotation, parent);
                        timer = attackSpeed;
                        timer += 8;
                        break;
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
