using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint rocketTurret;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
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
