using System.Collections; //coroutines
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    //public float timeBetweenEnemies = 0.5f;
    private float waveStartDelay = 0.5f;

    public Text countdownText;
    public Text waveText;
    private int waveNumber = 0;
    public AudioSource waveSpawnSound;
    public AudioSource tickSound;
    public GameManager gameManager;
    private bool count = true;
    
    void Start()
    {
        waveText.text = waves.Length.ToString();        
    }
    void Update()
    {
        //level won
        if(enemiesAlive == 0 && waveNumber == waves.Length)
        {
            //Level Won!
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }  
        //start next wave countdown
        else if(enemiesAlive == 0 && count == true)
        {
            StartCoroutine(Countdown());
        }             
    }
    IEnumerator Countdown()
    {
        count = false;
        for(int count = (int)timeBetweenWaves; count > 0; count --)
        {
            tickSound.Play();
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
        }

        StartCoroutine(SpawnWave());
        countdownText.text = "0";
        // count = false;   
        
    }
    IEnumerator SpawnWave()
    {
        waveText.text = (waves.Length-(waveNumber+1)).ToString();
        waveSpawnSound.Play();
        yield return new WaitForSeconds(waveStartDelay);
        Wave wave = waves[waveNumber];
        enemiesAlive = wave.numberOfEnemies;
        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
        count = true;
        PlayerStats.Rounds++;
        waveNumber++;        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
