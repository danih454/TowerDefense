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
        
        sellCost.text = "$" + target.turretBlueprint.sellAmount;
        transform.position = target.GetBuildPosition();
        Debug.Log(target.transform.ToString());

        if(!target.turretUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeCost.color = Color.white;
            upgradeText.color = Color.white;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.color = Color.gray;
            upgradeText.color = Color.gray;
            upgradeCost.text = "X";            
        }
    }

    public void Hide()
    {
        UI.SetActive(false);
    }
    
    public void Upgrade()
    {
        if(!target.turretUpgraded)
        {
            target.UpgradeTurret();
            BuildManager.instance.DeselectNode();
        } 

        
    }
    void Update()
    {
        if(target != null)
        {
            Debug.Log("targetSelected");
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
