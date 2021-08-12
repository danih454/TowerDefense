using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    void Update()
    {
        if(PlayerStats.Lives <= 0)
        {
            livesText.text = "0 LIVES";
        }
        else
        {
            livesText.text = PlayerStats.Lives + " LIVES";
        }
        
    }
    
}
