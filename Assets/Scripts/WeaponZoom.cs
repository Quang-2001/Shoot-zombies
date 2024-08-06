using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
   // [SerializeField] float zoomOutSensitivity = 2f;
   // [SerializeField] float zoomInSensitivity = 2f;


    FirstPersonController fpsController;


    bool zoomedInToggle = false;

    private void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
                
              
            }
            else
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
               
            }
        }
    }
}
