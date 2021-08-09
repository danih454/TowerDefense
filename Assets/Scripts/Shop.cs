using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret ()
    {
        Debug.Log("Selected Standard Turret");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseMissileTurret ()
    {
        Debug.Log("Selected Missile Turret");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);

    }
    public void PurchaseLaserTurret ()
    {
        Debug.Log("Selected Laser Turret");
        buildManager.SetTurretToBuild(buildManager.laserTurretPrefab);

    }
}
