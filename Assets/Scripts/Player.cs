using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Player : MonoBehaviour
{
   private int gold;
   private int startCash;
   private int health;
   private double attackSpeed;
   private double damage;

    public int GetGold(){return gold;}
    public void SetGold(int gold){this.gold = gold;}
    public double GetAttackSpeed(){return attackSpeed;}
    public void SetAttackSpeed(double attackSpeed){this.attackSpeed = attackSpeed;}
    public double GetDamage(){return damage;}
    public int GetHealth(){return health;}
    public int GetStartCash(){return startCash;}
    public void SetStartCash(int cash){startCash = cash;}
    public void SetHealth(int health){this.health = health;}
    public void SetDamage(double damage){this.damage = damage;}

    public void SaveData(){
        SaveLoad.SaveData(this);
    }

    public void LoadData(){
        PlayerData playerData = SaveLoad.LoadSave();

        health = playerData.health;
        gold = playerData.gold;
        damage = playerData.damage;
        attackSpeed = playerData.attackSpeed;
        startCash = playerData.startCash;
    }

    void Start(){
        LoadData();
    }

}
