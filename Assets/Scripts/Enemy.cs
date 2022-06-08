using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 60f;
    public int health = 100;
    private Transform target;
    public int value = 50;
    private int wavepointIndex = 0;
    public GameObject dieEffect;

    void Start()
    {
        target = Waypoints.points[0];
    }
    public void TakeDamege (int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
        GameObject dieStone = (GameObject)Instantiate(dieEffect, transform.position, transform.rotation);
        Destroy(dieStone, 10f);
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * direction.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GenNextWaypoint();
        }
        transform.LookAt(target);

    }

    void GenNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}