using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHellSpawner : MonoBehaviour
{

    public GameObject fireBall;
    public float projectileLife = 1f;
    public float speed = 1f;
    public int damage = 1;

    [SerializeField] private float firingRate = 1f;
    public float spinSpeed = 1f;
    public float spinSpeedGrow = 0.1f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    public bool selfDestruct = true;

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        spinSpeed = spinSpeed + spinSpeedGrow;

        if (spinSpeed >= 80 && selfDestruct)
        {
            Destroy(gameObject);
        }

        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + spinSpeed);

        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }
    private void Fire()
    {
        if (fireBall)
        {
            spawnedBullet = Instantiate(fireBall, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<SimpleFireball>().speed = speed;
            spawnedBullet.GetComponent<SimpleFireball>().Damage = damage;
            spawnedBullet.GetComponent<SimpleFireball>().projectileLife = projectileLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
