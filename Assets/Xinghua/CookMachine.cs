using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMachine:MonoBehaviour,IInteractable
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("I need more Candy");
            //Show text press e to gave
        }
    }
    public void Interact()
    {
        Debug.Log("Gave Candy to Calm down the grave walker");

        //Countdown the candy number put number in gameManager or Candy Manager



    }
}
