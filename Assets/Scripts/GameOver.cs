using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;
    public string mainMenuSceneName = "MainMenu";
    public AudioSource buttonClick;
    //public AudioSource gameOver;

    public void Retry()
    {
        buttonClick.Play();
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); 
    }

    public void Menu()
    {
        buttonClick.Play();
        sceneFader.FadeTo(mainMenuSceneName);
    }

}
