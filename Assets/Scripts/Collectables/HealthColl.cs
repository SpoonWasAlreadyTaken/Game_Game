using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthColl : MonoBehaviour, ICollect
{
    PlayerHP player;
    public int healthBuff = 1;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
    }

    public void Collect()
    {
        Debug.Log("Speed Up");
        Destroy(gameObject);

        player.GetComponent<PlayerHP>().IncreaseHP(healthBuff);
    }

}
