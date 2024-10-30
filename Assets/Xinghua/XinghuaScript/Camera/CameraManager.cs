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
    public bool isAlarmView;
    private void Start()
    {
        ActiveSoloCamera(defaultCamera);
        isAlarmView = false;
    }
    public void ActiveSoloCamera(GameObject cam)
    {
        foreach (var camera in virtualCameras)
        {
            camera.SetActive(false);
        }
        cam.SetActive(true);
    }
}

