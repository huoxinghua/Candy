using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CookMachine:MonoBehaviour,IInteractable
{
    [SerializeField] GameObject cameraView;
    public void Interact()
    {
        //Countdown the candy number 
        Inventory.Instance.UseCandy();
        CameraManager.Instance.ActiveSoloCamera(cameraView, true);

    }
  
}
