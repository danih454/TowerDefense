using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    private Renderer rend;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool turretUpgraded;

    BuildManager buildManager;

    private bool hovering = false;

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

    void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that.");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject) Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        buildManager.BuiltTurret();
    }

    public void UpgradeTurret()
    {
        if(PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that.");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret); //get rid of old turret

        GameObject _turret = (GameObject) Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        turretUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject sellEffect = (GameObject) Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(sellEffect, 5f);
        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseDown ()
    {
        if(EventSystem.current.IsPointerOverGameObject()) //is mouse over UI element?
        {
            return;
        } 
        if (turret != null) //select existing turret/node
        {
            buildManager.SelectNode(this);
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        else
        {
           BuildTurret(buildManager.GetTurretToBuild());
           rend.material.color = startColor;
        }
    }

    void Update()
    {
        if(hovering)
        {
            //continuously check if money avail
            if(buildManager.CanBuild && buildManager.HasMoney)
            {
                //change hover color
                rend.material.color = hoverColor;
            }
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
        hovering = true;
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
        hovering = false;
    }
}
