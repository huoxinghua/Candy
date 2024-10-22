using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMachine:MonoBehaviour,IInteractable
{
    public void Interact()
    {
        //Countdown the candy number 
        Inventory.Instance.UseCandy();
    }
}
