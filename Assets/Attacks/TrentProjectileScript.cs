using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrentProjectileScript : MonoBehaviour
{
    public float projectileSpeed;
    private Rigidbody2D rb;
    public int Damage = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHP player = hitInfo.GetComponent<PlayerHP>();
        if (player != null)
        {
            player.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

}
