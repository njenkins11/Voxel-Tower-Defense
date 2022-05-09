using System;
using System.Runtime.InteropServices;
using System.Threading;

[Serializable]
public class PlayerData
{
    public int gold;
    public int health;
    public int startCash;
    public float damage;
    public float attackSpeed;
    public int level;
    public int availableTalentpoints;

    public PlayerData(Player player){
        gold = player.GetGold();
        damage = player.GetDamage();
        attackSpeed = player.GetAttackSpeed();
        health = player.GetHealth();
        startCash = player.GetStartCash();
        level = player.GetLevel();
        availableTalentpoints = player.GetTalentPoints();
    }

    public PlayerData(){
        gold = 0;
        damage = 1;
        attackSpeed = 1;
        health = 20;
        startCash = 100;
        level = 1;
        availableTalentpoints = 1;
    }
}
