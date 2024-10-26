using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CookMachine : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject cameraView;
    private AIEnemy ememy;
    [SerializeField] private float maxDurability = 2f;
    [SerializeField] private float currentDurability;
    [SerializeField] Image HPBar;
    private void Start()
    {
        currentDurability = maxDurability;
        
        
    }
    public void Interact()
    {
        //Countdown the candy number 
        Inventory.Instance.CookCandy();
        //CameraManager.Instance.ActiveSoloCamera(cameraView, true);
        //HPBar.fillAmount = Mathf.Clamp(GameManager.Instance.currentCookDurability / GameManager.Instance.maxCookDurability, 0, 1);
       
    }
    public void CookMachineDamaged()
    {
        currentDurability--;
        HPBar.fillAmount = Mathf.Clamp(currentDurability / maxDurability, 0, 1);
        if (currentDurability <= 0)
        {
            Destroy(gameObject);
          
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<HumanNormal>())
        {
            maxDurability++;
        }
    }
    public void  ShowKeyToInteract()
    {
        // UI manager to show
    }


}
