using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : MonoBehaviour
{
    public Transform attackOrigin;
    public GameObject projectile;
    public int burstCount = 5;
    public float burstDelay = 0.2f;




    public void FireBallAttackStart()
    {
        StartCoroutine (FireBallAttack());
    }

    IEnumerator FireBallAttack()
    {

        for (int i = 0; i < burstCount; i++)
        {
            Instantiate(projectile, attackOrigin.position, attackOrigin.rotation);
            yield return new WaitForSeconds(burstDelay);
        }
    }
}