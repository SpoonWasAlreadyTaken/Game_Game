using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageColl : MonoBehaviour, ICollect
{
    PlayerCombat player;
    public int damageBuff = 1;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    public void Collect()
    {
        Debug.Log("Speed Up");
        Destroy(gameObject);

        player.GetComponent<PlayerCombat>().IncreaseDamage(damageBuff);
    }

}
