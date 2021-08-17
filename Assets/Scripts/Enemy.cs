using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed = 10f;

    private float health;
    public float startingHealth = 10;
    public GameObject enemyDeathEffect;
    public int moneyWon = 50;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    public void Start()
    {
        health = startingHealth;
        startSpeed = startSpeed + (Random.Range(-50, 51) / 100f);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health/startingHealth; //percentage [0,1]

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die ()
    {
        isDead = true;
        WaveSpawner.enemiesAlive--;   
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
