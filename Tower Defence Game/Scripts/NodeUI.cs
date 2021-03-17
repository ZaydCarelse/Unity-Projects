using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [Header("UI:")]
    public GameObject ui;
    public Text upgradeCostText;
    public Button upgradeButton;
    public Text sellCostText;
    public Button sellButton;

    [Header("Selection:")]
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCostText.text = target.currentTurretInfo.upgradeCost.ToString() + "G";
            upgradeButton.interactable = true;
        } else
        {
            upgradeCostText.text = "UPGRADED";
            upgradeButton.interactable = false;
        }

        sellCostText.text = target.currentTurretInfo.GetSellAmount().ToString() + "G";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
