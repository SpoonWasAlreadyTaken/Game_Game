using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireballProjectile : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public float projectileSpeed;
    private Rigidbody2D rb;
    public int Damage = 2;
    public float projectileLife = 2f;
    private float randomDir;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");

        System.Random random = new System.Random();
        randomDir = random.Next(-4, 5);

        Vector3 direction = PlayerCharacter.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x + randomDir, direction.y + randomDir).normalized * projectileSpeed;



        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    void FixedUpdate()
    {
        projectileLife -= Time.deltaTime;
        if (projectileLife < 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHP player = hitInfo.GetComponent<PlayerHP>();

        if (player != null)
        {
            player.TakeDamage(Damage);
            Destroy(gameObject);
        }

        if (hitInfo.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
