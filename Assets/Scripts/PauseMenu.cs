using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public SceneFader sceneFader;
    public GameObject ui;
    public AudioSource pauseMenu;
    public AudioSource buttonClick;

    public string mainMenuSceneName = "MainMenu";
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            playPauseMenu();
            Toggle();
        }
    }

    public void Toggle()
    {
        // menu
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;            
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void continueGame()
    {
        playButtonClick();
        Toggle();
    }

    public void Restart()
    {
        playButtonClick();
        Toggle(); //reset timescale
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);     
    }

    public void MainMenu()
    {
        playButtonClick();
        Toggle();
        sceneFader.FadeTo(mainMenuSceneName);
    }
    public void playPauseMenu()
    {
        pauseMenu.Play();
    }
    public void playButtonClick()
    {
        buttonClick.Play();
    }
}
