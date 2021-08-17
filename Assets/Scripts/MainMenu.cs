using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
    public SceneFader sceneFader;

    public AudioSource buttonClickSound;
    public void playButtonSound()
    {
        buttonClickSound.Play();
    }
    
    public void playLevel1()
    {
        playButtonSound();
        sceneFader.FadeTo("Level1");
    }
    public void playLevel2()
    {
        playButtonSound();
        sceneFader.FadeTo("Level2"); 
    }
    public void playLevel3()
    {
        playButtonSound();
        sceneFader.FadeTo("Level3"); 
    }
    public void playLevel4()
    {
        playButtonSound();
        sceneFader.FadeTo("Level4"); 
    }

    public void Quit()
    {
        playButtonSound();
        Application.Quit();
    }
}
