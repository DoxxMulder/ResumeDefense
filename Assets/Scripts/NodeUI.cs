using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject nodeUI;
    public GameObject upgradeUI;
    public GameObject shopUI;

    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;

    public TextMeshProUGUI sellAmount;

    public GameObject rangeProjector;

    private Node target;
    private float range;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        StartCoroutine(CheckMoney());

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            range = target.turretBlueprint.GetTurretRange(false);
        }
        else
        {
            range = target.turretBlueprint.GetTurretRange(true);
            upgradeCost.text = "Maxed out!";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        nodeUI.SetActive(true);
        shopUI.SetActive(false);
        // Activate upgradeUI, pass through the turret to be upgraded
        upgradeUI.SetActive(true);
        upgradeUI.GetComponent<UpgradeMenu>().SetTarget(target.turretBlueprint.GetTurret());
        
        rangeProjector.GetComponent<Projector>().orthographicSize = range;
        rangeProjector.SetActive(true);
    }

    IEnumerator CheckMoney()
    {
        for (; ; )
        {
            if(target.turretBlueprint != null)
            {
                if (PlayerStats.Money >= target.turretBlueprint.upgradeCost)
                {
                    upgradeButton.interactable = true;
                }
                else
                {
                    upgradeButton.interactable = false;
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void Hide()
    {
        nodeUI.SetActive(false);
        upgradeUI.SetActive(false);
        shopUI.SetActive(true);
        rangeProjector.SetActive(false);
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
