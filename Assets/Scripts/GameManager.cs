using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public AudioSource levelWon;
    public int nextLevelInt = 2;
    public GameObject shopUI;
    void Start() 
    {
        gameHasEnded = false;
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if(gameHasEnded)
        {
            return;
        }
        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if(PlayerStats.Lives <= 0 && !gameHasEnded)
        {            
            EndGame ();
        }
    }

    void EndGame()
    {
        gameHasEnded = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {

        levelWon.Play();
        gameHasEnded = true;
        PlayerPrefs.SetInt("levelReached", nextLevelInt);
        completeLevelUI.SetActive(true);
        shopUI.SetActive(false);
    }
}
