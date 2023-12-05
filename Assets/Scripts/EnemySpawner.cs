using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    private int totalWeight;
    public int maxWeight = 5;

    public float spawnInterval = 5f;
    private float timer;
    private float randomEnemy;
    public Vector2 spawnDistance;

    [Header("Enemies")]

    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    public GameObject enemyFour;
    public GameObject enemyFive;


    void Awake()
    {
        timer = spawnInterval;
        totalWeight = 0;
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        
        if (timer < 0 && totalWeight < maxWeight)
        {
            Vector2 pos = transform.position + new Vector3(UnityEngine.Random.Range(-spawnDistance.x / 2, spawnDistance.x / 2 ), UnityEngine.Random.Range(-spawnDistance.y / 2, spawnDistance.y / 2));

            spawnEnemy(pos);

            timer = spawnInterval;
        }
    }

    void spawnEnemy(Vector2 pos)
    {
        System.Random random = new System.Random();
        randomEnemy = random.Next(1, 6);

        switch (randomEnemy)
        {
            case 1:
                Debug.Log("Spawned an Enemy");
                Instantiate(enemyOne, pos, transform.rotation);
                totalWeight += 1;
                break;
            case 2:
                Debug.Log("Spawned an Enemy");
                Instantiate(enemyTwo, pos, transform.rotation);
                totalWeight += 1;
                break;
            case 3:
                Debug.Log("Spawned an Enemy");
                Instantiate(enemyThree, pos, transform.rotation);
                totalWeight += 1;
                break;
            case 4:
                Debug.Log("Spawned an Enemy");
                Instantiate(enemyFour, pos, transform.rotation);
                totalWeight += 1;
                break;
            case 5:
                Debug.Log("Spawned an Enemy");
                Instantiate(enemyFive, pos, transform.rotation);
                totalWeight += 1;
                break;
        }
    }

    public void reduceWeight(int weight)
    {
        totalWeight -= weight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawWireCube(transform.position, spawnDistance);
    }
}
