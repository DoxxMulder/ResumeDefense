using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100f;
    private float health;
    public int value = 10;

    [HideInInspector]
    public int partOfWave;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;
    public Gradient healthGradient;


    private void Start()
    {
        speed = startSpeed;
        partOfWave = PlayerStats.Rounds;
        health = startHealth;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        //Debug.Log("Took " + amount + " damage. Current health: " + health);
        float healthPct = health / startHealth;
        healthBar.fillAmount = healthPct;
        healthBar.color = healthGradient.Evaluate(healthPct);

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
