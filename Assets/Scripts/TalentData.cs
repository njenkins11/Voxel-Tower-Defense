using System;

[Serializable]
public class TalentData
{
    public int spellId;
    public int currentRank;
    public int maxRank;
    

    public TalentData(Talents talent){
        spellId = talent.GetSpellID();
        currentRank = talent.GetCurrentRank();
        maxRank = talent.GetMaxRank();
    }

    public TalentData(){
        spellId = 0;
        currentRank = 0;
        maxRank = 5;
    }
}
