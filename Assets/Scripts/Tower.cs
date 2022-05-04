using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public enum TOWER_TYPE{ MAGIC, LASER, MISSLE, TOWER_COUNT}

public class Tower : MonoBehaviour
{
    [SerializeField] private float defaultShootRate = 50f;
    [SerializeField] private float shootRate = 0f;
    [SerializeField] private float towerDamage = 0f;
    [SerializeField] private float defaultTowerDamage = 10f;
    [SerializeField] private float defaultTowerRange = 5f;
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
    private Player player;
    private GameObject playerObj;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null){
            playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.GetComponent<Player>();
            towerDamage = defaultTowerDamage * player.GetDamage();
            shootRate = defaultShootRate * player.GetAttackSpeed();

        }
        totalCost = purchaseCost;
        killAmount = 0;
    }

    void Update()
    {
        sellPrice = totalCost - (totalCost * percentSell);
        player = playerObj.GetComponent<Player>();
        towerDamage = defaultTowerDamage * player.GetDamage();
        shootRate = defaultShootRate * player.GetAttackSpeed();

    }

    public void UpgradeTower()
    {
        if(currentUpgradeAmount < maxAmountOfUpgrades)
        {
            defaultTowerDamage += incrementDamageRateUpgrade;
            defaultShootRate -= incrementShootRateUpgrade;
            defaultTowerRange += incrementRangeRateUpgrade;
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
    public float GetTowerRange(){ return defaultTowerRange;}
    public GameObject GetTowerHead(){return towerHead;}
    public int GetCost(){return purchaseCost;}
    public int GetCurrentAmountUpgrade(){return currentUpgradeAmount;}
    public int GetMaxUpgrade(){return maxAmountOfUpgrades;}
    public float GetSellPrice(){return sellPrice;}
    public void IncrementKillAmount(){killAmount++;}
    public int GetKillAmount(){return killAmount;}
}
