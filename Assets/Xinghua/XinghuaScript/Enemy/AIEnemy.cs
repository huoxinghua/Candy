using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : Npc
{
    private CookMachine cookMachine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HumanNormal>())
        {
            Debug.Log("transfer people");
            var humanNormal = other.gameObject.GetComponent<HumanNormal>();
            if (humanNormal != null)
            {
                humanNormal.BeenChanged();
            }
        }
        else if(other.gameObject.GetComponent<CookMachine>())
        {
            Debug.Log("cook machine damage");
            cookMachine = other.gameObject.GetComponent<CookMachine>();
            Debug.Log("cook machine" + cookMachine);
            cookMachine.CookMachineDamaged();
        }

    
    }
}
