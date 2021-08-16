using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public SceneFader sceneFader;
    public GameObject ui;

    public string mainMenuSceneName = "MainMenu";
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        // camera controls

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

    public void Restart()
    {
        Toggle(); //reset timescale
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);     
    }

    public void MainMenu()
    {
        Toggle();
        sceneFader.FadeTo(mainMenuSceneName);
    }
}
