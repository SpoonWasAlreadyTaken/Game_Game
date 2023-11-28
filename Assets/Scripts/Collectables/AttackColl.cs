using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackColl : MonoBehaviour, ICollect
{
    PlayerCombat player;
    public int attackBuff = 1;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    public void Collect()
    {
        Debug.Log("Speed Up");
        Destroy(gameObject);

        player.GetComponent<PlayerCombat>().IncreaseAttack(attackBuff);
    }

}

