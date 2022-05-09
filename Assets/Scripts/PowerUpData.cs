using System;

[Serializable]
public class PowerUpData
{
    public int spellId;
    public int currentRank;
    public int maxRank;
    public int cost;
    

    public PowerUpData(PowerUp powerUp){
        spellId = powerUp.GetSpellID();
        currentRank = powerUp.GetCurrentRank();
        maxRank = powerUp.GetMaxRank();
        cost = powerUp.GetCost();
    }

    public PowerUpData(){
        spellId = 0;
        currentRank = 0;
        maxRank = 5;
        cost = 250;
    }
}
