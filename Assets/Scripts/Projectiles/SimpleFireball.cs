using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFireball : MonoBehaviour
{
    public float projectileLife = 1f;  
    public float rotation = 0f;
    public float speed = 1f;
    public int Damage = 2;

    private Vector2 spawnPoint;
    private float timer = 0f;


    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }


    void FixedUpdate()
    {
        if (timer > projectileLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }


    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
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

