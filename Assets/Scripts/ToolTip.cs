using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject frame;
    Text infoText;
    Vector3 min, max;
    Camera mainCamera;
    RectTransform rect;
    float offset = 10f;
    

    void Start(){
        frame = GameObject.FindGameObjectWithTag("Tooltip");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //infoText.text = gameObject.GetComponent<PowerUp>().information.text;
        rect = frame.GetComponent<RectTransform>();
  
        min = new Vector3(0,0,0);
        max = new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight, 0);
        if(frame != null)
            frame.transform.position = new Vector3(-1000,-1000,-1000);
    }

    public void OnPointerEnter(PointerEventData data){
        frame.transform.position = new Vector3(0,0,0);

        //Vector3 position = new Vector3(Input.mousePosition.x + rect.rect.width, 
        //Input.mousePosition.y - (rect.rect.height / 2 + offset), 0f);
        
        //frame.transform.position = new Vector3(Mathf.Clamp(position.x, min.x + rect.rect.width/2, max.x - rect.rect.width/2),
        //Mathf.Clamp(position.y, min.y + rect.rect.height / 2, max.y - rect.rect.height / 2), position.z);
    }

    public void OnPointerExit(PointerEventData data){
        frame.transform.position = new Vector3(-1000,-1000,-1000);
    }
}
