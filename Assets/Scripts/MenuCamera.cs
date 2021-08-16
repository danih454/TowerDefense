using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    private bool moveToFirstLocation = false;
    private bool moveToSecondLocation = false;

    private float mainMenuY = (float) -62.868;
    private float levelSelectY = (float) 25.642;
    private float smooth = 5.0f;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }
    public void LevelSelect()
    {
        Debug.Log("LevelSelect");
        moveToFirstLocation = false;               
        moveToSecondLocation = true; 
    }

    public void MainMenuSelect()
    {
        moveToSecondLocation = false;  
        moveToFirstLocation = true;              
    }

    void Update()
    {
        if(moveToSecondLocation)
        {
            Debug.Log("Rotating");
            Quaternion target = Quaternion.Euler(0, levelSelectY, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
        if(transform.rotation.y == levelSelectY)
        {
            moveToSecondLocation = false;
        }
        if(moveToFirstLocation)
        {
            Quaternion target = originalRotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
        if(transform.rotation.y == mainMenuY)
        {
            moveToFirstLocation = false;
        }
        
    }
}
