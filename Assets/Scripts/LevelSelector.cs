using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;
    public Button[] levelButtons;
    public AudioSource buttonSound;

    void Start ()
    {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i+1 > levelReached)
            {
                //levelButtons[i].interactable = false;
            }
        }
    }

    public void Select(string levelName)
    {
        buttonSound.Play();
        sceneFader.FadeTo(levelName);
    }
}
