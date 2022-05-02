using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float maxFOV = 100f;
    [SerializeField] private float minFOV = 10f;
    [SerializeField] private float speed = 1;
    [SerializeField] private float currentFOV;
    
    void Update()
    {
        currentFOV = Camera.main.fieldOfView;
        currentFOV += (Input.GetAxis("Mouse ScrollWheel") * speed) * -1;
        currentFOV = Mathf.Clamp(currentFOV, minFOV, maxFOV);
        Camera.main.fieldOfView = currentFOV;
    }
}
