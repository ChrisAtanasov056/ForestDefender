using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradeCost;
    private Node target;
    public Button upgradeButton;
    public Text sellAmount;
    public Vector3 positionOffset;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.transform.position + positionOffset;
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turrentBlueprint.upgradedCost.ToString();
            upgradeButton.interactable = true;

        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellAmount.text = "$" + target.turrentBlueprint.GetSellAmount();
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
     public void UpdateTurrent()
    {
        target.UpgradeTurrent();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurrent();
        BuildManager.instance.DeselectNode();
    }
}
