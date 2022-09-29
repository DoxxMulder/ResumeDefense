using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    
    private GameObject turretToBuild;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
