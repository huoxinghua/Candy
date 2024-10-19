using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    //keep static if write here
    private static int candyCount;
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
           
            gameObject.SetActive(false);
            //add collect sound here
            UpdateCandy();
            
        }
    }

    private void UpdateCandy()
    {
        candyCount++;
        Debug.Log("candy  count is " + candyCount);
    }
}
