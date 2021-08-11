using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    public int health = 10;

    private Transform target;
    private int wavepointIndex = 0;

    public GameObject enemyDeathEffect;

    public int moneyWon = 50;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update() 
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //normalized = gives it a fixed speed

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        GameObject effect = (GameObject)Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.Money += moneyWon;
        Destroy(gameObject);        
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }


}
