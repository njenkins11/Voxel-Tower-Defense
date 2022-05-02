using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    private GameObject tower = null;
    private GameObject towerLocation = null;
    public void UpgradeTower()
    {
        if(tower == null)
        {
            Debug.Log("No tower to upgrade!");
        }
        else if(PlayerController.GetMoney() < tower.GetComponent<Tower>().GetUpgradeCost())
        {
            Debug.Log("Not enough money to upgrade!");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameUIController>().Alert("Not enough money to upgrade tower!");
        }
        else
        {
            PlayerController.SetMoney(PlayerController.GetMoney() - tower.GetComponent<Tower>().GetUpgradeCost());
            tower.GetComponent<Tower>().UpgradeTower();
            Debug.Log("Upgraded!");
        }
        gameObject.SetActive(false);
    }
    public void SellTower()
    {
        PlayerController.SetMoney(PlayerController.GetMoney() + (int) tower.GetComponent<Tower>().GetSellPrice());
        towerLocation.GetComponent<TowerSelector>().setHasTower(false);
        Destroy(tower);
        gameObject.SetActive(false);
    }
    public void SetTower(GameObject tower){this.tower = tower;}
    public void SetTowerLocation(GameObject location){towerLocation = location;}
}
