using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollect : MonoBehaviour
{
    public UnityEvent CameraTrigger;
    protected string  itemName;
    

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            gameObject.SetActive(false);
            //add collect sound here
            SoundManager.Instance.PlaySFX("collectSound");
           
           if (GameManager.Instance != null)
            {
                Inventory.Instance.AddItem(itemName, 1);
            }
            else
            {
                Debug.LogError("GameManager.Instance is null! GameManager is not initialized.");
            }
           // CameraTrigger?.Invoke();
        }

    }

}
