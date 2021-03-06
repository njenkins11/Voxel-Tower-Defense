using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text levelUpText;
    [SerializeField] private Text[] buyOpt;
    [SerializeField] private GameObject[] costAmount;
    [SerializeField] private Text upgradeText;
    [SerializeField] private Text sellText;
    [SerializeField] private Text specificationText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject talentsPanel;
    [SerializeField] private GameObject[] talentTitles;
    [SerializeField] private GameObject[] talentTrees;
    private bool isPaused;
    private string message;
  

    void Start()
    {
        pausePanel = GameObject.FindGameObjectWithTag("PausePanel");
        pauseButton = GameObject.FindGameObjectWithTag("PauseButton");
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        talentsPanel = GameObject.FindGameObjectWithTag("TalentsPanel");
        talentTitles = GameObject.FindGameObjectsWithTag("TalentTitle");
        talentTrees = GameObject.FindGameObjectsWithTag("TalentTree");
        ActivateTalentOne();
        pausePanel.SetActive(false);
        deathPanel.SetActive(false); 
        talentsPanel.SetActive(false);
        isPaused = false;
        levelUpText.enabled = false;
    }
    void Update()
    {
       UpdateTextUI();

        if(Input.GetKeyDown(KeyCode.Escape))
            PauseAndUnpause();
    }

    public void Death()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }

    IEnumerator LevelComplete()
    {
        levelUpText.enabled = true;
        levelUpText.text = "Level up!" + " Rewarded $" + GetComponent<PlayerController>().GetRewardAmount() + ". Next wave soon!";
        yield return new WaitForSeconds(10);
        levelUpText.enabled= false;
    }

    public void Alert(string message)
    {
        this.message = message;
        StartCoroutine("ErrorMessage");
    }

    IEnumerator ErrorMessage()
    {
        levelUpText.enabled = true;
        levelUpText.text = message;
        yield return new WaitForSeconds(5);
        levelUpText.enabled= false;
    }

    public void UpdateTextUI()
    {
        if(healthText != null)
        healthText.text = GetComponent<PlayerController>().GetHealth().ToString();
        if(moneyText != null)
        moneyText.text = "$" + PlayerController.GetMoney();
        if(timeText != null)
        timeText.text =  ((int) GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>().GetTimer()).ToString();
        if(levelText != null)
        levelText.text = GetComponent<PlayerController>().GetLevel().ToString();
    }

    public void MusicPauseAndUnpause()
    {
        GameObject musicController = GameObject.FindGameObjectWithTag("MusicController");

        if(musicController.GetComponent<MusicController>().GetPlayMusic())
            musicController.GetComponent<MusicController>().SetPlayMusic(false);
        else
            musicController.GetComponent<MusicController>().SetPlayMusic(true);
    }

    public void PauseAndUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            pausePanel.SetActive(false);
            pauseButton.SetActive(true);
            Time.timeScale = 1;
        }
        else
        {
            isPaused = true;
            pausePanel.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0;
        }
    }

    // Towers
    public void UpdateTowerBuyingOpt()
    {
        for(int i = 0; i < buyOpt.Length; i++)
        {
            buyOpt[i].text = costAmount[i].GetComponent<Tower>().GetTOWER_TYPE() + "- $ " + costAmount[i].GetComponent<Tower>().GetCost();
        }
    }

    public void UpdateUpgrade(GameObject tower)
    {
        Tower selectedTower = tower.GetComponent<Tower>();
        specificationText.text = "Damage: " + selectedTower.GetTowerDamage() + "\n"+
                                "Range: " +selectedTower.GetTowerRange() + "\n" +
                                "Upgrades: " +selectedTower.GetCurrentAmountUpgrade() +" /" + selectedTower.GetMaxUpgrade() + "\n" +
                                "Total Kills: " + selectedTower.GetKillAmount();
        upgradeText.text = "Upgrade: $" + selectedTower.GetUpgradeCost();
        sellText.text = "Sell: $" + selectedTower.GetSellPrice();
    }

    // Talents
    public void ActivateTalentsPanel(){
        if(talentsPanel.activeInHierarchy)
            talentsPanel.SetActive(false);
        else
            talentsPanel.SetActive(true);
    }

    public void ActivateTalentOne(){
        for(int i = 0; i < talentTitles.Length; i++)
            if(i != 0){
                talentTitles[i].GetComponent<Button>().interactable = true;
                talentTrees[i].SetActive(false);
            }
            else{
                talentTitles[i].GetComponent<Button>().interactable = false;
                talentTrees[i].SetActive(true);
            }
    }
    public void ActivateTalentTwo(){
        for(int i = 0; i < talentTitles.Length; i++)
            if(i != 1){
                talentTitles[i].GetComponent<Button>().interactable = true;
                talentTrees[i].SetActive(false);
            }
            else{
                talentTitles[i].GetComponent<Button>().interactable = false;
                talentTrees[i].SetActive(true);
            }
    }
    public void ActivateTalentThree(){
        for(int i = 0; i < talentTitles.Length; i++)
            if(i != 2){
                talentTitles[i].GetComponent<Button>().interactable = true;
                talentTrees[i].SetActive(false);
            }
            else{
                talentTitles[i].GetComponent<Button>().interactable = false;
                talentTrees[i].SetActive(true);
            }
    }
}
