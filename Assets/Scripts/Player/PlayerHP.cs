using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public GameManager GameManager;

    private bool isDead;
    [SerializeField] AudioSource deathSound;

    void Start()
    {
        currentHP = maxHP;
    }

    public void IncreaseHP(int healthBuff)
    {
        maxHP += healthBuff;
        currentHP += healthBuff;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Dead");
            Destroy(gameObject);
            GameManager.gameOver();
            deathSound.Play();
        }
    }

}
