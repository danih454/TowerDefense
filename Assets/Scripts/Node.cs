using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    public Vector3 positionOffset;

    private GameObject turret;

    BuildManager buildManager;

    void Start ()
    {
        rend = GetComponent<Renderer>(); //lookup once and cache
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown ()
    {
        if(EventSystem.current.IsPointerOverGameObject()) //is mouse over UI element?
        {
            return;
        }
        if(buildManager.GetTurretToBuild() == null)
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
            //build a turret
            GameObject turretToBuild = buildManager.GetTurretToBuild();
            turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        }
    }

    void OnMouseEnter ()
    {
        if(EventSystem.current.IsPointerOverGameObject()) //is mouse over UI element?
        {
            return;
        }

        if(buildManager.GetTurretToBuild() != null)
        {
            rend.material.color = hoverColor;
        }        
    }

    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }
}
