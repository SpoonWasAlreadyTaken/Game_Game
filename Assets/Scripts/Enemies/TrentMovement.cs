using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrentEnemy : MonoBehaviour
{
    public GameObject TrentAGo;
    public GameObject TrentBGo;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float TrentSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = TrentBGo.transform;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == TrentBGo.transform)
        {
            rb.velocity = new Vector2(TrentSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-TrentSpeed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.8f && currentPoint == TrentBGo.transform)
        {
            flip();
            currentPoint = TrentAGo.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.8f && currentPoint == TrentAGo.transform)
        {
            flip();
            currentPoint = TrentBGo.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(TrentAGo.transform.position, 0.5f);
        Gizmos.DrawWireSphere(TrentBGo.transform.position, 0.5f);
        Gizmos.DrawLine(TrentAGo.transform.position, TrentBGo.transform.position);
    }
}
