using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    private float levelSelectY = (float) 25;
    private float helpMenuY = (float) 130;
    private float creditsY = (float) 224;
    private float smooth = 10.0f;
    private Quaternion originalRotation;
    private bool canTurn = true;

    void Start()
    {
        originalRotation = transform.rotation;
    }
    //Button Functions
    public void MainMenuSelect()
    {       
        StartCoroutine(MoveCameraTo(originalRotation));          
    }
    public void LevelSelect()
    {
        Quaternion target = Quaternion.Euler(0, levelSelectY, 0);
        StartCoroutine(MoveCameraTo(target)); 
    }

    public void HelpSelect()
    {
        Quaternion target = Quaternion.Euler(0, helpMenuY, 0);
        StartCoroutine(MoveCameraTo(target));
    }

    public void CreditsSelect()
    {
        Quaternion target = Quaternion.Euler(0, creditsY, 0);
        StartCoroutine(MoveCameraTo(target));
    }

    IEnumerator MoveCameraTo(Quaternion target)
    {                
        if(canTurn)
        {
            canTurn = false;
            while(!(transform.eulerAngles.y >= target.eulerAngles.y - 0.02f) || !(transform.eulerAngles.y <= target.eulerAngles.y + 0.01f))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                yield return new WaitForSeconds(0.0001f);
            }
            canTurn = true;
        }       
    }
}
