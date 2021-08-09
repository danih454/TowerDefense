using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    void Awake ()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }
        instance = this;
    }

    void Start ()
    {
        turretToBuild = null;
    }    
    
}
