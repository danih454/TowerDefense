using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    private Renderer rend;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    void Start ()
    {
        rend = GetComponent<Renderer>(); //lookup once and cache
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown ()
    {
        if(EventSystem.current.IsPointerOverGameObject()) //is mouse over UI element?
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Cannot build another turret here!");
            return;
        }
        else
        {
           buildManager.BuildTurretOn(this);
        }
    }

    void OnMouseEnter ()
    {
        if(EventSystem.current.IsPointerOverGameObject()) //is mouse over UI element?
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return; 
        }  
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor; 
        } else{
            rend.material.color = notEnoughMoneyColor; 
        }
        
             
    }

    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }
}
