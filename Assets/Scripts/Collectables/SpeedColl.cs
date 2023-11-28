using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedColl : MonoBehaviour, ICollect
{

    PlayerMover player;
    public int speedBuff = 1;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMover>();
    }

    public void Collect()
    {
        Debug.Log("Speed Up");
        Destroy(gameObject);

        player.GetComponent<PlayerMover>().IncreaseSpeed(speedBuff);
    }

}
