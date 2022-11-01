using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return Mathf.RoundToInt(cost * 0.8f);
    }

    public float GetTurretRange(bool isUpgraded)
    {
        if (isUpgraded)
        {
            return upgradedPrefab.GetComponent<Turret>().range;
        }
        return prefab.GetComponent<Turret>().range;
    }
}
