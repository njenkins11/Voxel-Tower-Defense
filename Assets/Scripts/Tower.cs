using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TOWER_TYPE{ MAGIC, LASER, MISSLE, TOWER_COUNT}

public class Tower : MonoBehaviour
{
    [SerializeField] private float shootRate = 50f;
    [SerializeField] private float towerDamage = 10f;
    [SerializeField] private float towerRange = 5f;
    [SerializeField] private int purchaseCost = 50;
    [SerializeField] private int baseUpgradeCost = 20;
    [SerializeField] private int incrementUpgrateCostAmount = 2;
    [SerializeField] private int incrementShootRateUpgrade = 5;
    [SerializeField] private int incrementDamageRateUpgrade = 5;
    [SerializeField] private int incrementRangeRateUpgrade = 1;
    [SerializeField] private int maxAmountOfUpgrades = 3;
    [SerializeField] private float percentSell = 0.70f;
    [SerializeField] private TOWER_TYPE towerType = TOWER_TYPE.LASER;
    [SerializeField] public GameObject towerHead;
    private int currentUpgradeAmount = 0;
    private float sellPrice;
    private int totalCost;
    private int killAmount;

    void Start()
    {
        totalCost = purchaseCost;
        killAmount = 0;
    }

    void Update()
    {
        sellPrice = totalCost - (totalCost * percentSell);
    }

    public void UpgradeTower()
    {
        if(currentUpgradeAmount < maxAmountOfUpgrades)
        {
            towerDamage += incrementDamageRateUpgrade;
            shootRate -= incrementShootRateUpgrade;
            towerRange += incrementRangeRateUpgrade;
            totalCost += baseUpgradeCost;
            baseUpgradeCost *= incrementUpgrateCostAmount;
            currentUpgradeAmount++;
            gameObject.transform.localScale += new Vector3(0.1f,0.1f,0.1f); 
        }
    }

    public int GetUpgradeCost(){return baseUpgradeCost;}
    public float GetShootRate(){return shootRate;}
    public TOWER_TYPE GetTOWER_TYPE(){return towerType;}
    public float GetTowerDamage(){return towerDamage;}
    public float GetTowerRange(){ return towerRange;}
    public GameObject GetTowerHead(){return towerHead;}
    public int GetCost(){return purchaseCost;}
    public int GetCurrentAmountUpgrade(){return currentUpgradeAmount;}
    public int GetMaxUpgrade(){return maxAmountOfUpgrades;}
    public float GetSellPrice(){return sellPrice;}
    public void IncrementKillAmount(){killAmount++;}
    public int GetKillAmount(){return killAmount;}
}
