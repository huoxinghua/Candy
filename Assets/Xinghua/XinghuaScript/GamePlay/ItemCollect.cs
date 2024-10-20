using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    ////keep static if write here
    //private static int candyCount;
   
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
        }
        
        
    }

}
