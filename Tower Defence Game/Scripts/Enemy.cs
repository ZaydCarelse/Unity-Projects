using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement:")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    [Header("Player:")]
    public float health = 100;

    [Header("Economy:")]
    public int value = 50;

    [Header("AV:")]
    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;    
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

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

        Destroy(gameObject);
    }
}

