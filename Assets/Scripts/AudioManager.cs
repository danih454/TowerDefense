using System;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public AudioSource beatLevel;
    public AudioSource enemyWin;
    public AudioSource laser;// put laser on turret instead
    public AudioSource loseGame;
    public AudioSource notEnoughMoney;
    

//FindObjectOfType<AudioManager>().playEnemyWin();
    public void playEnemyWin()
    {
        enemyWin.Play();
    }
    public void playLaser()
    {
        laser.Play();
    }
    public void stopLaser()
    {
        laser.Stop();
    }
    public void playNotEnoughMoney()
    {
        notEnoughMoney.Play();
    }

    
    
}
