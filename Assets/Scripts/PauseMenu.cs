using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    public void MainMenu()
    {

    }
}
