using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded;
    public GameObject gameOverUI;

    void Start() 
    {
        gameHasEnded = false;
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
}
