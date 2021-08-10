using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserTurret;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Selected Standard Turret");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileTurret ()
    {
        Debug.Log("Selected Missile Turret");
        buildManager.SelectTurretToBuild(missileLauncher);

    }
    public void SelectLaserTurret ()
    {
        Debug.Log("Selected Laser Turret");
        buildManager.SelectTurretToBuild(laserTurret);

    }
}


