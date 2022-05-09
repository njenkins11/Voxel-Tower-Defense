using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    [SerializeField] private int startMoney = 0;
    [SerializeField] private Player player;
    private int health;
    private static int cash;
    private int level;
    private bool grantedLevel;
    private int rewardMoney;
    private readonly int goldReward = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        health = player.GetHealth();
        cash = player.GetStartCash();
        if(cash == 0)
            cash = 100;
        grantedLevel = true;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevel();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        bool goldRewarded = false;
        if(health <= 0)
        {
            Debug.Log("Game Over!");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameUIController>().Death();
            
            if(!goldRewarded){
                player.SetGold(player.GetGold() + (goldReward * level));
                goldRewarded = true;
            }
        }
    }

    public void UpdateLevel()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !grantedLevel)
        {
            level++;
            grantedLevel = true;
            rewardMoney = startMoney * level;
            GetComponent<GameUIController>().StartCoroutine("LevelComplete");
            cash += rewardMoney;
        }
        else if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
            grantedLevel = false;
    }

    public int GetHealth(){return health;}
    public static int GetMoney(){return cash;}
    public static void SetMoney(int updateMoney) {cash = updateMoney;}
    public int GetLevel(){return level;}
    public int GetRewardAmount(){return rewardMoney;}
}
