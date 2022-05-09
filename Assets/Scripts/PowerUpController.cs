using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public PowerUp[] powerUps;

    void Start()
    {
        LoadPower();
    }

    public void LoadPower(){
        PowerUpData[] powerData = SaveLoad.LoadPower();
       
        if(powerData != null)
            for(int i = 0; i < powerData.Length; i++){
                powerUps[i].SetMaxRank(powerData[i].maxRank);
                powerUps[i].SetCurrentRank(powerData[i].currentRank);
                powerUps[i].SetSpellID(powerData[i].spellId);
            }
    }

    public void SavePower(){
        PowerUpData[] powerData = new PowerUpData[powerUps.Length];
        for(int i = 0; i < powerUps.Length; i++){
            powerData[i] = new PowerUpData(powerUps[i]);
        }

        SaveLoad.SavePower(powerData);
    }

    void OnDestroy(){
        SavePower();
    }
}
