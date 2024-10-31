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
    [SerializeField] private GameObject rotatePart;
    [SerializeField] Image HPBar;
    public bool isMachineDestroyed;

    
    public float rotationSpeed = 50f;

    private void Start()
    {
        currentDurability = maxDurability;
    }
    
    private void FixedUpdate()
    {
        rotatePart.transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
    }
    public void Interact()
    {
        UIManager.Instance.CookMachineUI.SetActive(true);
        //Countdown the candy number 
        Inventory.Instance.CookCandy();
        //HPBar.fillAmount = Mathf.Clamp(GameManager.Instance.currentCookDurability / GameManager.Instance.maxCookDurability, 0, 1);
        StartCoroutine(HideCookMachineUIAfterDelay());
    }


    private IEnumerator HideCookMachineUIAfterDelay()
    {
        //2s
        yield return new WaitForSeconds(2f);

        // hide CookMachineUI
        UIManager.Instance.CookMachineUI.SetActive(false);
    }
    public void CookMachineDamaged()
    {
        currentDurability--;
        HPBar.fillAmount = Mathf.Clamp(currentDurability / maxDurability, 0, 1);
        if (currentDurability <= 0)
        {
            UIManager.Instance.hpBarMachine.SetActive(false);
            Destroy(gameObject);
            isMachineDestroyed = true;  
        } 
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<HumanNormal>())
        {
            maxDurability++;
        }
        else if (other.gameObject.GetComponent<PlayerController>())
        {
            UIManager.Instance.CookMachineUI.SetActive(true);
            StartCoroutine(HideCookMachineUIAfterDelay());
        }
    }
   


}
