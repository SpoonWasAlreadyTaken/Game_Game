using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    bool FaceR = true;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x< 0 && FaceR)
        {
            flip();
        }
        if (movement.x > 0 && !FaceR)
        {
            flip();
        }
    }
    
    public void IncreaseSpeed(int speedBuff)
    {
        moveSpeed += speedBuff;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void flip()
    {
        FaceR = !FaceR;
        transform.Rotate(0f, 180f, 0f);
    }


}
