using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager: Singleton<CameraManager>
{
    public UnityEvent CameraTrigger;
    private GameObject lastCamera;
    private GameObject alarmCamera;
    private GameObject currentCamera;
    [SerializeField] GameObject[] virtualCameras;
    [SerializeField] GameObject defaultCamera;
    private void Start()
    {
        ActiveSoloCamera(defaultCamera,false);
       // currentCamera = defaultCamera;
    }
    public void ActiveSoloCamera(GameObject cam,bool isAlarming)
    {
        if (isAlarming)
        {
            alarmCamera = cam;
            cam.SetActive(true);
           
        }
        else
        {
            currentCamera = cam;
            foreach (var camera in virtualCameras)
            {
                camera.SetActive(false);
            }
            cam.SetActive(true);
            lastCamera = cam;
        }
    }
    
    public void AlarmCamera(GameObject cam,bool isAlarming)
    {
        
        ActiveSoloCamera(cam, true);
        StartCoroutine(SwitchBackToLastCamera());
    }

    IEnumerator SwitchBackToLastCamera()
    {
        Debug.Log("Switching back in 5 seconds");
        yield return new WaitForSeconds(5f); 
        currentCamera.SetActive(true);         
        alarmCamera.SetActive(false);     
        Debug.Log("Switched back to: " + lastCamera.name);
    }
}

