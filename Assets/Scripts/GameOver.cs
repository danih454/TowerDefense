using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    public SceneFader sceneFader;
    public string mainMenuSceneName = "MainMenu";
    public AudioSource buttonClick;
    public AudioSource gameOver;

    void OnEnable()
    {
        playGameOver();
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        playButtonClick();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); 
    }

    public void Menu()
    {
        playButtonClick();
        sceneFader.FadeTo(mainMenuSceneName);
    }
    void playButtonClick()
    {
        buttonClick.Play();
    }
    void playGameOver()
    {
        gameOver.Play();
    }

}
