using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedColl : MonoBehaviour, ICollect
{
    public static event Action OnSpeedUpCollected;
    public void Collect()
    {
        Debug.Log("Speed Up");
        Destroy(gameObject);
        OnSpeedUpCollected?.Invoke();
    }

}
