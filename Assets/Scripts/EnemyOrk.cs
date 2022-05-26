using UnityEngine;

public class EnemyOrk : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;

    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
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
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}