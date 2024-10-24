using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CookMachine : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject cameraView;
    private AIEnemy ememy;
    [SerializeField] private float maxDurability = 2f;
    private float currentDurability;
    private void Start()
    {
        currentDurability = maxDurability;
    }
    public void Interact()
    {
        //Countdown the candy number 
        Inventory.Instance.UseCandy();
        CameraManager.Instance.ActiveSoloCamera(cameraView, true);
    }
    public void CookMachineDamaged()
    {
        currentDurability--;
        if (currentDurability <= 0)
        {
            Destroy(gameObject);
        }
        GameManager.Instance.GameOver();    
    }
    
  

}
