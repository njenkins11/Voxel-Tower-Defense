using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int startHealth = 20;
    [SerializeField] private int startMoney = 0;
    private int health;
    private static int money;
    private int level;
    private bool grantedLevel;
    private int rewardMoney;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        money = startMoney;
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
        
        if(health <= 0)
        {
            Debug.Log("Game Over!");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameUIController>().Death();
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
            money += rewardMoney;
        }
        else if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
            grantedLevel = false;
    
    }

    public int GetHealth(){return health;}
    public static int GetMoney(){return money;}
    public static void SetMoney(int updateMoney) {money = updateMoney;}
    public int GetLevel(){return level;}
    public int GetRewardAmount(){return rewardMoney;}
}
