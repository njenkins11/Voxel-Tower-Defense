using System;

[Serializable]
public class PlayerData
{
    public int gold;
    public double damage;
    public double attackSpeed;

    public PlayerData(Player player){
        gold = player.GetGold();
        damage = player.GetDamage();
        attackSpeed = player.GetAttackSpeed();
    }
}
