using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public TextMeshProUGUI turretName;

    public Button upgradeRange;
    public Button upgradeDamage;
    public Button upgradeRate;

    public Slider sliderRange;
    public Slider sliderDamage;
    public Slider sliderRate;

    private Turret turret;
    private int turretDamage;


    public void SetTarget(Turret _turret)
    {
        turret = _turret;
    }

    void Start()
    {
        turretName.text = turret.name;
        sliderRange.maxValue = turret.range * 2;
        sliderRange.value = turret.range;
        if (!turret.useLaser)
        {
            turretDamage = turret.bulletPrefab.GetComponent<Bullet>().damage;
        }
        else
        {
            turretDamage = turret.damageOverTime;
        }
        sliderDamage.maxValue = turretDamage * 2;
        sliderDamage.value= turretDamage;
        sliderRate.maxValue = turret.fireRate * 2;
        sliderRate.value = turret.fireRate;
    }
    public void UpgradeRange()
    {
        if (turret.range < sliderRate.maxValue)
        {
            turret.range += 1;
            sliderRange.value += 1;
        }        
    }

    public void UpgradeDamage()
    {
        if (turretDamage < sliderDamage.maxValue - 5)
        {
            turretDamage += 5;
        }
    }

    public void UpgradeRate()
    {
        if (turret.fireRate < sliderRate.maxValue)
        {
            turret.fireRate += 0.25f;
        }
    }
}
