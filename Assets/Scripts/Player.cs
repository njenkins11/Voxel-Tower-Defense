using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Player : MonoBehaviour
{
      [SerializeField] private int gold;
      [SerializeField] private int startCash;
      [SerializeField] private int health;
      [SerializeField] private float attackSpeed;
      [SerializeField] private float damage;
      [SerializeField] private int level;
      [SerializeField] private float goldIncrease;
      [SerializeField] private float expIncrease;
      [SerializeField] private int talentPoints;

    public void SaveData(){
        SaveLoad.SaveData(this);
    }

    void OnDestroy(){
        SaveData(); 
    }

    public void LoadData(){
        PlayerData playerData = SaveLoad.LoadSave();

        health = playerData.health;
        gold = playerData.gold;
        damage = playerData.damage;
        attackSpeed = playerData.attackSpeed;
        startCash = playerData.startCash;
        goldIncrease = playerData.goldIncrease;
        expIncrease = playerData.expIncrease;
    }

    void Start(){
        LoadData();
    }

    public float GetExpIncrease(){return expIncrease;}
    public void SetExpIncrease(float exp){expIncrease = exp;}
    public float GetGoldIncrease(){return goldIncrease;}
    public void SetGoldIncrease(float gold){goldIncrease = gold;}
    public int GetGold(){return gold;}
    public void SetGold(int gold){this.gold = gold;}
    public float GetAttackSpeed(){return attackSpeed;}
    public void SetAttackSpeed(float attackSpeed){this.attackSpeed = attackSpeed;}
    public float GetDamage(){return damage;}
    public int GetHealth(){return health;}
    public int GetStartCash(){return startCash;}
    public void SetStartCash(int cash){startCash = cash;}
    public void SetHealth(int health){this.health = health;}
    public void SetDamage(float damage){this.damage = damage;}
    public int GetLevel(){return level;}
    public void SetLevel(int level){this.level = level;}
    public int GetTalentPoints(){return talentPoints;}
    public void DecreaseTalentPoints(){talentPoints--;}

}
