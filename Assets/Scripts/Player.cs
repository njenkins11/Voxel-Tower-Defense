using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Player : MonoBehaviour
{
   private int gold;
   private double attackSpeed;
   private double damage;

    public int GetGold(){return gold;}
    public void SetGold(int gold){this.gold = gold;}
    public double GetAttackSpeed(){return attackSpeed;}
    public void SetAttackSpeed(double attackSpeed){this.attackSpeed = attackSpeed;}
    public double GetDamage(){return damage;}
    public void SetDamage(double damage){this.damage = damage;}

}
