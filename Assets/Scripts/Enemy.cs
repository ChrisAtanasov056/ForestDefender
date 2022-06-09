using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float health = 100f;
    public int value = 50;
    public GameObject dieEffect;

    void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamege (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Slow (float amount)
    {
        speed = startSpeed * (1f - amount);
    }
    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
        GameObject dieStone = (GameObject)Instantiate(dieEffect, transform.position, transform.rotation);
        Destroy(dieStone, 10f);
    }

    
}