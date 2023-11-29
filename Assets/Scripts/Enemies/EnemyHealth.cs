using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    public GameObject buffDrop;
    Vector3 centerPosition;



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
        Debug.Log("Enemy Dead");

        centerPosition = transform.position + new Vector3(0f, 1.5f, 0f);
        Destroy(gameObject);
        Instantiate(buffDrop, centerPosition, transform.rotation);

    }


}
