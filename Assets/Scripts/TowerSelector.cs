using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject towerSelectionPanel;
    [SerializeField] private GameObject towerUpgradePanel;
    [SerializeField] private GameObject gameController;
    private GameObject tower;
    private bool hasTower = false;
    void Awake()
    {
        towerSelectionPanel = GameObject.FindGameObjectWithTag("TowerSelectionPanel");
        towerUpgradePanel = GameObject.FindGameObjectWithTag("TowerUpgradePanel");
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Start()
    {
        towerSelectionPanel.SetActive(false);
        towerUpgradePanel.SetActive(false);
    }

    public void SelectTower()
    {

        // Upgrade / Sell tower
        if(hasTower)
        {
            gameController.GetComponent<GameUIController>().UpdateUpgrade(tower);
            towerUpgradePanel.SetActive(true);
            towerSelectionPanel.SetActive(false);
            towerUpgradePanel.GetComponent<TowerUpgrade>().SetTower(tower);
            towerUpgradePanel.GetComponent<TowerUpgrade>().SetTowerLocation(gameObject);
        }
        // Add Tower
        else
        {
            gameController.GetComponent<GameUIController>().UpdateTowerBuyingOpt();
            towerUpgradePanel.SetActive(false);
            towerSelectionPanel.SetActive(true);
            towerSelectionPanel.GetComponent<CreateTower>().SetTowerLocation(gameObject);
        }
    }

    public void setHasTower(bool hasTower){this.hasTower = hasTower;}
    public void SetTower(GameObject tower){this.tower = tower;}
}
