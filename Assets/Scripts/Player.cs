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

    public void SaveData(){
        SaveLoad.SaveData(this);
    }

    void OnApplicationQuit(){
        SaveData(); 
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
