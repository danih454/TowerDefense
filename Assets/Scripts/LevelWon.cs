using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWon : MonoBehaviour
{
    public SceneFader sceneFader;
    public string mainMenuSceneName = "MainMenu";
    public AudioSource buttonClick;
    public string nextLevel = "Level2";


    public void ContinueGame()
    {
        buttonClick.Play();
        sceneFader.FadeTo(nextLevel); 
    }

    public void Menu()
    {
        buttonClick.Play();
        sceneFader.FadeTo(mainMenuSceneName);
    }
}
