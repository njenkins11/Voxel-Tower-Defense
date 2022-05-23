using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    private GameObject towerLocation;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject towerPrefab2;
    [SerializeField] private GameObject towerPrefab3;
    public void AddTowerOne()
    {
        if(PlayerController.GetMoney() < towerPrefab.GetComponent<Tower>().GetCost())
        {
            Debug.Log("Not enough money to add tower!");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameUIController>().Alert("Not enough moeny to add tower!");
        }
        else
        {
            PlayerController.SetMoney(PlayerController.GetMoney() - towerPrefab.GetComponent<Tower>().GetCost());            
            towerLocation.GetComponent<TowerSelector>().SetTower(Instantiate(towerPrefab, towerLocation.transform.position, Quaternion.identity));
            towerLocation.GetComponent<TowerSelector>().setHasTower(true);
        }
        gameObject.SetActive(false);
    }
    public void AddTowerTwo()
    {
        if(PlayerController.GetMoney() < towerPrefab2.GetComponent<Tower>().GetCost())
        {
            Debug.Log("Not enough money to add tower!");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameUIController>().Alert("Not enough moeny to add tower!");
        }
        else
        {
            PlayerController.SetMoney(PlayerController.GetMoney() - towerPrefab2.GetComponent<Tower>().GetCost());            
            towerLocation.GetComponent<TowerSelector>().SetTower(Instantiate(towerPrefab2, towerLocation.transform.position, Quaternion.identity));
            towerLocation.GetComponent<TowerSelector>().setHasTower(true);
        }
        gameObject.SetActive(false);
    }

     public void AddTowerThree()
    {
        if(PlayerController.GetMoney() < towerPrefab3.GetComponent<Tower>().GetCost())
        {
            Debug.Log("Not enough money to add tower!");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameUIController>().Alert("Not enough moeny to add tower!");
        }
        else
        {
            PlayerController.SetMoney(PlayerController.GetMoney() - towerPrefab3.GetComponent<Tower>().GetCost());            
            towerLocation.GetComponent<TowerSelector>().SetTower(Instantiate(towerPrefab3, towerLocation.transform.position, Quaternion.identity));
            towerLocation.GetComponent<TowerSelector>().setHasTower(true);
        }
        gameObject.SetActive(false);
    }


    public GameObject GetTowerLocation(){return towerLocation;}
    public void SetTowerLocation(GameObject location){towerLocation = location;}
 
}
