using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;

    public GameObject buildEffect;
    public GameObject sellEffect;

    public Outline standardTurretButton;
    public Outline missileTurretButton;
    public Outline laserTurretButton;
    public AudioSource notEnoughMoney;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
    

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

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        Debug.Log("CanBuild!");
        turretToBuild = turret;
        if(selectedNode != null)
        {
            selectedNode.isSelected = false;
        }
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectNode(Node node)
    {
        if(node == selectedNode)
        {
            DeselectNode();
            node.isSelected = false;
            return;
        }        
        selectedNode = node;
        node.isSelected = true;
        turretToBuild = null;
        nodeUI.SetTarget(selectedNode);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();        
    }

    public void BuiltTurret()
    {
        turretToBuild = null;
        //auto de-select button in shop        
        DeselectShopButtons();
    }

    private void DeselectShopButtons()
    {
        standardTurretButton.enabled = false;
        missileTurretButton.enabled = false;
        laserTurretButton.enabled = false;
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
