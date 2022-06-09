using LightningBolt;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public Transform target;

    [Header("Use Bullet (default)")]
    public GameObject bulletPrefab;
    
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public GameObject lightingBold;
    private GameObject lb;

    [Header("Unity Setup Fields")]
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;
    

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDiscnace = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDiscnace)
            {
                shortestDiscnace = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDiscnace <= range) 
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                Destroy(lb);
            }
            return;
        }
        //tartgetLock
        LockOnTarget();
        if (useLaser)
        {
            
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    
    }

    void Laser()
    {
        if (lb == null)
        {
            GameObject laser = (GameObject)Instantiate<GameObject>(lightingBold);
            lb = laser;
        }
        lb.GetComponent<LightningBoltScript>().StartPosition = firePoint.position;
        lb.GetComponent<LightningBoltScript>().EndPosition = target.position;
       
           //lineRenderer.transform.GetChild(0).gameObject.transform.position = firePoint.position;
           //lineRenderer.transform.GetChild(1).gameObject.transform.position = target.position;
            
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(transform.rotation.x, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
