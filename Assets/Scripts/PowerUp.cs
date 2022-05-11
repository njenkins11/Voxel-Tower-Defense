using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum POWER_TYPE {ATTACKSPEED, DAMAGE, HEALTH, EXP, GOLD};
    [SerializeField] private int spellId;
    [SerializeField] private int currentRank;
    [SerializeField] private int maxRank;
    [SerializeField] private Text text;
    [SerializeField] private int cost = 250;
    [SerializeField] private POWER_TYPE powerType = POWER_TYPE.ATTACKSPEED;
    [SerializeField] private Player player;
    public Text information;
    
    public PowerUp(PowerUpData data){
        spellId = data.spellId;
        currentRank = data.currentRank;
        maxRank = data.maxRank;
        cost = data.cost;
    }

    public void addRank(){
        if(currentRank < maxRank && player.GetGold() >= cost){
            currentRank++;
            player.SetGold(player.GetGold() - cost);
            PowerUpController.AddAttributes(this);
            cost *= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(text != null)
            text.text = currentRank+"/"+maxRank;
    }

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public POWER_TYPE GetPOWER_TYPE(){return powerType;}
    public int GetCost(){return cost;}
    public void SetCost(int cost){this.cost = cost;}
    public int GetSpellID(){return spellId;}
    public int GetCurrentRank(){return currentRank;}
    public int GetMaxRank(){return maxRank;}
    public void SetSpellID(int spellId){this.spellId = spellId;}
    public void SetCurrentRank(int cur){currentRank = cur;}
    public void SetMaxRank(int rank){maxRank = rank;}
}
