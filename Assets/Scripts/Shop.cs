using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Turrets")]
    public TurretBlueprint standardTurret;
    public TextMeshProUGUI standardTurretCost;
    public TurretBlueprint rocketTurret;
    public TextMeshProUGUI rocketTurretCost;
    public TurretBlueprint laserTurret;
    public TextMeshProUGUI laserTurretCost;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        standardTurretCost.text = "$" + standardTurret.cost.ToString();
        rocketTurretCost.text = "$" + rocketTurret.cost.ToString();
        laserTurretCost.text = "$" + laserTurret.cost.ToString();
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }


    public void SelectRocketTurret()
    {
        Debug.Log("Rocket Turret Selected");
        buildManager.SelectTurretToBuild(rocketTurret);
    }
    public void SelectLaserTurret()
    {
        Debug.Log("Laser Turret Selected");
        buildManager.SelectTurretToBuild(laserTurret);
    }

}
