using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed = 10f;

    public float health = 10;
    public GameObject enemyDeathEffect;
    public int moneyWon = 50;


    public void TakeDamage(float amount)
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

    public void Slow(float slowAmount)
    {
        speed = startSpeed * slowAmount;
    }
}
