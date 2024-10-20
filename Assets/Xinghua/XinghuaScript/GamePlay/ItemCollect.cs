using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollect : MonoBehaviour
{
    public UnityEvent CameraTrigger;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            gameObject.SetActive(false);
            //add collect sound here
           
           if (GameManager.Instance != null)
            {
                Debug.Log("GameManager instance is valid. Calling UpdateItemCount.");
                GameManager.Instance.AddItemCount();
            }
            else
            {
                Debug.LogError("GameManager.Instance is null! GameManager is not initialized.");
            }
            CameraTrigger?.Invoke();
        }
        
        
    }

}
