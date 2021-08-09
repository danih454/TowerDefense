using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    public Vector3 positionOffset;

    private GameObject turret;

    void Start ()
    {
        rend = GetComponent<Renderer>(); //lookup once and cache
        startColor = rend.material.color;
    }

    void OnMouseDown ()
    {
        if (turret != null)
        {
            Debug.Log("Cannot build another turret here!");
            return;
        }
        else
        {
            //build a turret
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        }
    }

    void OnMouseEnter ()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }
}
