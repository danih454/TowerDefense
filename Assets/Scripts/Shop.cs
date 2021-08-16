using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserTurret;

    public Outline standardTurretButton;
    public Outline missileTurretButton;
    public Outline laserTurretButton;

    private Outline selectedOutline;

    void Start ()
    {
        buildManager = BuildManager.instance;
        DeselectButtons();
    }

    public void SelectStandardTurret ()
    {
        if(!standardTurretButton.enabled)
        {
            Debug.Log("Selected Standard Turret");
            // outline button
            standardTurretButton.enabled = true;
            buildManager.SelectTurretToBuild(standardTurret);
        }
        else
        {
            buildManager.BuiltTurret();
            standardTurretButton.enabled = false;
        }
        
    }
    public void SelectMissileTurret ()
    {
        if(!missileTurretButton.enabled)
        {
            Debug.Log("Selected Missile Turret");
            //outline button
            missileTurretButton.enabled = true;
            buildManager.SelectTurretToBuild(missileLauncher);
        }
        else
        {
            buildManager.BuiltTurret();
            missileTurretButton.enabled = false;
        }
        

    }
    public void SelectLaserTurret ()
    {
        if(!laserTurretButton.enabled)
        {
            Debug.Log("Selected Laser Turret");
            //outline button
            laserTurretButton.enabled = true;
            buildManager.SelectTurretToBuild(laserTurret);
        }
        else
        {
            buildManager.BuiltTurret();
            laserTurretButton.enabled = false;
        }  

    }

    public void DeselectButtons()
    {
        standardTurretButton.enabled = false;
        missileTurretButton.enabled = false;
        laserTurretButton.enabled = false;
    }
}


