using System.Collections; //coroutines
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int enemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 0.5f;

    public Text countdownText;

    private float countdown = 2f;
    private int waveNumber = 0;
    

    // Update is called once per frame
    void Update()
    {

        if(enemiesAlive>0)
        {
            return;
        }

        //only run this if the previous wave ended
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime; //time passed since last frame was drawn
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        countdownText.text = string.Format("{0:00.00}", countdown);
        
        
    }
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];
        enemiesAlive = wave.numberOfEnemies;
        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
        PlayerStats.Rounds++;
        waveNumber++;

        if(waveNumber == waves.Length)
        {
            //Level Won!
            this.enabled = false;
        }
        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        //enemiesAlive++;
    }
}
