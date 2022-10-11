using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int value = 10;

    [HideInInspector]
    public int partOfWave;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
        partOfWave = PlayerStats.Rounds;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }


}
