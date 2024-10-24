using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : Npc
{
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
    }
}
