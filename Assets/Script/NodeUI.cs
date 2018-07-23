using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    private Node target;
    public GameObject ui;
    private BuildManager buildManager;
    public Text upgradeText;
    public Text sellText;
    public Button upgradeButton;
    public Text sellButton;

    private void Start()
    {
        ui.SetActive(false);
        buildManager = BuildManager.instance;
    }

    public void HideNodeUI()
    {
        ui.SetActive(false);
    }

    public void SetTarget (Node _target) // different action when _turret is null or not
    {
        if (_target == null)
            ui.SetActive(false);
        else
        {
            target = _target;
            transform.position = _target.GetBuildingPosition();
            sellButton.text = "Sell\n€" + target.turretCostsInfo.GetSellCost();
            if (!target.GetIsUpgraded())
            {
                upgradeText.text = "Upgrade\n€ " + target.turretCostsInfo.upgradeCost;
                upgradeButton.interactable = true;  
            }
            else
            {
                upgradeButton.interactable = false; // for make not interactive the button when the turret on node is already upgraded
                upgradeText.text = "Upgrade\nDONE";
            }
            ui.SetActive(true);
        }
    }

    public void UpgradeTurret()
    {
        if (!buildManager.CanUpdate(target))
            return;
        target.UpgradeTurretOnNode();
        buildManager.DeselectNode();    // for hide immediatly the update/sell panel after update operation
    }

    public void SellTurret()
    {
        target.SellTurretOnNode();
        buildManager.DeselectNode();
    }

}
