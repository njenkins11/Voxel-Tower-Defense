using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Timeline;

public class PowerUpController : MonoBehaviour
{
    public PowerUp[] powerUps;
    public static readonly float SPEED_INCREASE = 0.05f;
    public static readonly float DAMAGE_INCREASE = 0.25f;
    public static readonly int HEALTH_INCREASE = 5;
    public static readonly float EXP_INCREASE = 0.25f;
    public static readonly float GOLD_INCREASE = 0.25f;

    void Start()
    {
        LoadPower();
    }

    public static void AddAttributes(PowerUp powerUp) { 
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
        switch(powerUp.GetPOWER_TYPE()){
            case PowerUp.POWER_TYPE.ATTACKSPEED:
                player.SetAttackSpeed(player.GetAttackSpeed()-SPEED_INCREASE);
                break;
            case PowerUp.POWER_TYPE.DAMAGE:
                player.SetDamage(player.GetDamage() + DAMAGE_INCREASE);
                break;
            case PowerUp.POWER_TYPE.HEALTH:
                player.SetHealth(player.GetHealth() + HEALTH_INCREASE);
                break;
            case PowerUp.POWER_TYPE.EXP:
                player.SetExpIncrease(player.GetExpIncrease() + EXP_INCREASE);
                break;
            case PowerUp.POWER_TYPE.GOLD:
                player.SetGoldIncrease(player.GetGoldIncrease() + GOLD_INCREASE);
                break;
        }     

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
