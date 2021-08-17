using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;

    [Header("Use Bullets (default")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int laserDamageOverTime = 30;
    public float slowAmount = 0.5f; //0 = no effect, 1 = stand still
    public LineRenderer lineRenderer;
    public ParticleSystem laserImpactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]
    public float rotationSpeed = 10f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    
    public Transform firePoint;    
    private Transform target;
    private Enemy enemy;

    // AudioManager audioManager;
    private bool startLaser = false; //for audio


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //call update target every 0.5 seconds        
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            enemy = target.GetComponent<Enemy>();
        }
        else 
        {
            target = null;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir); //how to rotate to look in that direction
        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Update()
    {
        if(target == null)
        {
            if(useLaser)
            {
                if(lineRenderer.enabled)
                {
                    //stop playing audio
                    FindObjectOfType<AudioManager>().stopLaser();
                    lineRenderer.enabled = false;
                    laserImpactEffect.Stop();
                    impactLight.enabled = false;
                    startLaser = true;
                }
            }
            return;
        }        
        LockOnTarget();
        if(useLaser)
        {
            Laser();
            if(startLaser)
            {
                FindObjectOfType<AudioManager>().playLaser();
                startLaser = false;
            }
        }
        else
        {
            if(fireCountdown <= 0f)
            {            
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
        
    }

    void Laser() 
    {
        enemy.TakeDamage(laserDamageOverTime * Time.deltaTime);
        enemy.Slow(slowAmount);
        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserImpactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
        laserImpactEffect.transform.position = target.position + dir.normalized;
    }

    void Shoot() //talking to another script attacheted to an instiated object
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
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
