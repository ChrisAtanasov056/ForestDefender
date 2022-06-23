using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    
    private Transform target;
    private int wavepointIndex = 0;
    
    private Enemy enemy;
    void Start()
    {
        
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
       

    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(enemy.speed * Time.deltaTime * direction.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GenNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
        
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
