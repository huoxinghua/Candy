using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager: Singleton<CameraManager>
{
    [SerializeField] GameObject[] virtualCameras;
    public UnityEvent CameraTrigger;
    public void ActiveSoloCamera(GameObject cam)
    {
        foreach(var camera in virtualCameras)
        {
            cam.SetActive(false);
        }
       cam.SetActive(true);
    }
}
