using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class GeneralUIController : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text goldText;
    [SerializeField] private Text damageText;
    [SerializeField] private Text attackSpeedText;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "" + player.GetHealth();
        goldText.text = "" + player.GetGold();
    }
}
