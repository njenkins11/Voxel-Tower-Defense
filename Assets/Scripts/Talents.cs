using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        text.text = currentRank+"/"+maxRank;
    }

    public void addTalentPoint(){
        if(currentRank < maxRank)
            currentRank++;
        text.text = currentRank+"/"+maxRank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
