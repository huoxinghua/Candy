using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            Debug.Log("candy get");
            gameObject.SetActive(false);
            //add sound here
        }
    }
}
