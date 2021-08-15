using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject UI;

    public Text upgradeCost;    
    public Text upgradeText;
    public Button upgradeButton;
    public Text sellCost;

    public void SetTarget(Node _target)
    {
        UI.SetActive(true);
        target = _target;
        
        
        transform.position = target.GetBuildPosition();
        Debug.Log(target.transform.ToString());

        if(!target.turretUpgraded)
        {
            sellCost.text = "$" + target.turretBlueprint.GetSellAmount();
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeCost.color = Color.white;
            upgradeText.color = Color.white;
            upgradeButton.interactable = true;
        }
        else
        {
            sellCost.text = "$" + target.turretBlueprint.GetUpgradedSellAmount();
            upgradeButton.interactable = false;
            upgradeCost.color = Color.gray;
            upgradeText.color = Color.gray;
            upgradeCost.text = "X";            
        }
    }

    public void Hide()
    {
        UI.SetActive(false);
        target = null;
    }
    
    public void Upgrade()
    {
        if(!target.turretUpgraded)
        {
            target.UpgradeTurret();
            BuildManager.instance.DeselectNode();
        }
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
    void Update()
    {
        if(target != null)
        {
            if(PlayerStats.Money <= target.turretBlueprint.upgradeCost)
            {
                upgradeButton.interactable = false;
                upgradeCost.color = Color.gray;
                upgradeText.color = Color.gray;
            }
            else
            {
                upgradeCost.color = Color.white;
                upgradeText.color = Color.white;
                upgradeButton.interactable = true;
            }
        }       
    }
}
