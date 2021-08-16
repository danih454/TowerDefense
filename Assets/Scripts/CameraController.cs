using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minZ = -1000f;
    public float maxZ = 1000f;

    //private bool doMovement = true;

    void Update()
    {
        if(GameManager.gameHasEnded)
        {
            this.enabled = false;
            return;
        }
        
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) 
        {
            if(transform.position.z < 0f)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //Vector3.forward = (0,0,1)
            }            
        } 
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) 
        {
            if(transform.position.z > -50f)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); //Vector3.forward = (0,0,1)
            }            
        } 
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) 
        {
            if(transform.position.x < 25f)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); //Vector3.forward = (0,0,1)
            }            
        } 
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) 
        {
            if(transform.position.x > -25f)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); //Vector3.forward = (0,0,1)
            }            
        } 

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 500;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        transform.position = pos;

    }
}
