using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 200f;
    private float health;
    public int value = 50;
    public GameObject dieEffect;

    [Header("Unity Stuff")]
    public Image healthBar;
    public Text healthText;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        healthText.text = health.ToString();
    }
    public void TakeDamege (float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth ;
        healthText.text = health.ToString();
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