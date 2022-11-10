using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class for accessing/storing build info
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

    //TODO: Depreciate this, move it to the turret script
    public float GetTurretRange(bool isUpgraded)
    {
        if (isUpgraded)
        {
            return upgradedPrefab.GetComponent<Turret>().range;
        }
        return prefab.GetComponent<Turret>().range;
    }

    public Turret GetTurret()
    {
        return prefab.GetComponent<Turret>();
    }
}
