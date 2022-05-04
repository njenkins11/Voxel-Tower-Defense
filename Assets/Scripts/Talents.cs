using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
[Serializable]
public class Talents : MonoBehaviour
{
    [SerializeField] private int spellId;
    [SerializeField] private int currentRank;
    [SerializeField] private int maxRank;
    [SerializeField] private Text text;
    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
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
