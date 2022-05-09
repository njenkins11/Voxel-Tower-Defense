using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private int spellId;
    [SerializeField] private int currentRank;
    [SerializeField] private int maxRank;
    [SerializeField] private Text text;
    
    public PowerUp(PowerUpData data){
        spellId = data.spellId;
        currentRank = data.currentRank;
        maxRank = data.maxRank;
    }

    public void addTalentPoint(){
        if(currentRank < maxRank)
            currentRank++;
        text.text = currentRank+"/"+maxRank;
    }

    // Update is called once per frame
    void Update()
    {
        if(text != null)
            text.text = currentRank+"/"+maxRank;
    }

    public int GetSpellID(){return spellId;}
    public int GetCurrentRank(){return currentRank;}
    public int GetMaxRank(){return maxRank;}
    public void SetSpellID(int spellId){this.spellId = spellId;}
    public void SetCurrentRank(int cur){currentRank = cur;}
    public void SetMaxRank(int rank){maxRank = rank;}
}
