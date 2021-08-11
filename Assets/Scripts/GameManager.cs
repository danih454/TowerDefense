using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.Lives <= 0 && !gameHasEnded)
        {            
            EndGame ();
        }
    }

    void EndGame()
    {
        gameHasEnded = true;
        Debug.Log("Game Over!");
    }
}
