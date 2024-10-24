using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanNormal : Npc
{
    Npc npc;
    private void Start()
    {
        npc = gameObject.GetComponent<Npc>();
        HunmanMove();
    }
    private void HunmanMove()
    {
        npc.NpcMove();
    }
}
