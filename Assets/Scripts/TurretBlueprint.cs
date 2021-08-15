using System.Collections;
using UnityEngine;


[System.Serializable] //tag to show up in the inspector with multiple fields
public class TurretBlueprint 
{
    public int cost;
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int upgradeCost;
    public int sellAmount;


    public int GetSellAmount()
    {
        return cost / 2;
    }
    public int GetUpgradedSellAmount()
    {
        return (cost+upgradeCost) / 2;
    }
}
