using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject frame;
    public Text infoText;
    public String info;

    void Start(){
        frame = GameObject.FindGameObjectWithTag("Tooltip");
        infoText = GameObject.FindGameObjectWithTag("TooltipInfo").GetComponent<Text>();

        if(frame != null)
            frame.transform.position = new Vector3(-365,0,-20);
    }

    public void OnPointerEnter(PointerEventData data){
        frame.SetActive(false);
        infoText.text = info;
        frame.transform.position = new Vector3(620,70,0);
        frame.SetActive(true);
    }

    public void OnPointerExit(PointerEventData data){
        frame.transform.position = new Vector3(-1000,-1000,-1000);
    }
}
