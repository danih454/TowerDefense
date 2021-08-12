using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 50f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
    public int damage = 50;

    public void Seek (Transform _target)
    {
        target = _target;
    }


    void Update()
    {
        if(target == null) //target was already destroyed
        {
            Destroy(gameObject); //destroy what this script is attached to 
            return;
        }

        //find direction bullet needs to go in to track target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame) //hit target
        {
            HitTarget();
            return;
        }
        else
        {
            transform.Translate(dir.normalized * distanceThisFrame, Space.World); 
            transform.LookAt(target);
        }


    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        
        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        Destroy(gameObject);
        
    }

    void Explode ()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }        
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

