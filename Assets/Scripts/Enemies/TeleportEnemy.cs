using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeleportEnemy : MonoBehaviour
{
    private GameObject PlayerCharacter;
    private SpriteRenderer sprite;
    public float minteleportCD = 1f;
    public float detectionRange = 10f;
    public float teleportTime = 0.5f;

    private float timer;


    void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        timer = minteleportCD;
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, PlayerCharacter.transform.position);
        if (distance < detectionRange)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                StartCoroutine (Teleport());

                System.Random random = new System.Random();
                timer = minteleportCD + random.Next(0, 3);
            }
        }
    }


    IEnumerator Teleport()
    {
        sprite.color = Color.red;

        yield return new WaitForSeconds(teleportTime);
        gameObject.transform.position = PlayerCharacter.transform.position;
        sprite.color = Color.white;

        Debug.Log("Teleported");
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
