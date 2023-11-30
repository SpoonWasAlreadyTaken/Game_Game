using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject PlayerCharacter;
    public ChargeAttack chargeAttack;

    public float speed = 5f;
    public float rotateSpeed = 1f;
    public float detectionRange = 10f;

    bool FaceR = true;
    private float rot;



    void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, PlayerCharacter.transform.position);
        if (distance < detectionRange)
        {
            Vector3 direction = PlayerCharacter.transform.position - transform.position;
            if (!chargeAttack.disableMovement)
            {
                rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
            }
            rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 180); 
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
