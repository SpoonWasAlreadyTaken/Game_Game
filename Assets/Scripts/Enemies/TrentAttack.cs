using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrentAttack : MonoBehaviour
{
    public Transform attackOrigin;
    public GameObject projectile;
    public float attackSpeed = 5f;
    private float timer;

    private void Awake()
    {
        timer = attackSpeed;
    }


    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Instantiate(projectile, attackOrigin.position, attackOrigin.rotation);
            timer = attackSpeed;
        }
    }
}
