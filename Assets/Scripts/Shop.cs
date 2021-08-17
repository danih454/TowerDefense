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
    public AudioSource shopButton;
    public AudioSource deselect;

    void Start ()
    {
        buildManager = BuildManager.instance;
        DeselectButtons();
    }

    public void SelectStandardTurret ()
    {
        if(!standardTurretButton.enabled)
        {
            playShopButton();
            standardTurretButton.enabled = true;// outline button
            buildManager.SelectTurretToBuild(standardTurret);
        }
        else
        {
            buildManager.BuiltTurret();
            playDeselectButton();
            standardTurretButton.enabled = false;
        }
        
    }
    public void SelectMissileTurret ()
    {
        if(!missileTurretButton.enabled)
        {
            playShopButton();
            //outline button
            missileTurretButton.enabled = true;
            buildManager.SelectTurretToBuild(missileLauncher);
        }
        else
        {
            buildManager.BuiltTurret();
            playDeselectButton();
            missileTurretButton.enabled = false;
        }
        

    }
    public void SelectLaserTurret ()
    {
        if(!laserTurretButton.enabled)
        {
            playShopButton();
            //outline button
            laserTurretButton.enabled = true;
            buildManager.SelectTurretToBuild(laserTurret);
        }
        else
        {
            buildManager.BuiltTurret();
            playDeselectButton();
            laserTurretButton.enabled = false;
        }  

    }

    public void DeselectButtons()
    {
        standardTurretButton.enabled = false;
        missileTurretButton.enabled = false;
        laserTurretButton.enabled = false;
    }

    public void playShopButton()
    {
        shopButton.Play();
    }
    public void playDeselectButton()
    {
        deselect.Play();
    }
}


