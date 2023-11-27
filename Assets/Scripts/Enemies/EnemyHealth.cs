using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;


    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int Damage)
    {
        currentHP -= Damage;

        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Trent Dead");

        Destroy(gameObject);
    }


}
