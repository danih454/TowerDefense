using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

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
        }


    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
    }
}

