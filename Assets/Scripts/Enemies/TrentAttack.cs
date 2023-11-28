using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrentAttack : MonoBehaviour
{
    public Transform attackOrigin;
    public GameObject projectile;
    public float attackSpeed = 5f;
    private float timer;
    private GameObject PlayerCharacter;
    public float attackDistance = 10f;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        timer = attackSpeed;
    }


    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, PlayerCharacter.transform.position);

        if (distance < attackDistance)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Instantiate(projectile, attackOrigin.position, attackOrigin.rotation);
                timer = attackSpeed;
            }
        }
    }

}
