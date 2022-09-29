using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
