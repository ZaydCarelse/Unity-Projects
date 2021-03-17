using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Movement:")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    [Header("Player:")]
    public float startHealth = 100;
    private float health;

    [Header("Economy:")]
    public int value = 50;

    [Header("AV:")]
    public GameObject deathEffect;

    [Header("UI:")]
    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float slowPercentage)
    {
        speed = startSpeed * (1f - slowPercentage);
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject dEffect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(dEffect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}

