using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("door")]
    public float pushThreshold = 10;
    public float currentPushThreshold;
    public float doorDamageAmount;
    [Header("candy devourer")]
    public float currentDurability;
    public float maxDurability = 2f;
    private void Start()
    {
        doorDamageAmount = 2f;
    }
    public void GameOver()
    {
        Debug.Log("Game over");
        Time.timeScale = 0f;
    }

  

}
