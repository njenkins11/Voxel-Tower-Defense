using System;

[Serializable]
public class PowerUpData
{
    public int spellId;
    public int currentRank;
    public int maxRank;
    

    public PowerUpData(PowerUp powerUp){
        spellId = powerUp.GetSpellID();
        currentRank = powerUp.GetCurrentRank();
        maxRank = powerUp.GetMaxRank();
    }

    public PowerUpData(){
        spellId = 0;
        currentRank = 0;
        maxRank = 5;
    }
}
