using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionFinder : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float Direction;
    public bool Above;

    

    void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        Debug.DrawLine(transform.position, direction, Color.green);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);


        if (angle > 50 && angle < 130)
        {
            Above = true;
        }
        else
        {
            Above = false;
        }


        if (angle > 90 || angle < -90)
        {
            Direction = -1;
        }
        else if (angle < 90 || angle > -90)
        {
            Direction = 1;
        }
    }
}
