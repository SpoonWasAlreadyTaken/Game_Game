using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangeColl : MonoBehaviour, ICollect
{
    PlayerCombat player;
    public float rangeBuff = 0.1f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    public void Collect()
    {
        Debug.Log("Range Up");
        Destroy(gameObject);

        player.GetComponent<PlayerCombat>().IncreaseRange(rangeBuff);
    }
}
