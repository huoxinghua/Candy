using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("door")]
    public float pushThreshold = 10;
    public float currentPushThreshold;
    public float doorDamageAmount;
    public float doorIncreaseAmount;

    [Header("candy devourer")]
    public float currentDurability;
    public float maxDurability = 2f;
    public float candyEatMaxAmount;
    public float candyEatAlready;
    public float candyEnergy =2f;

    [Header("candy value")]
    private float candy;
    private void Start()
    {
      //  doorDamageAmount = 2f;
       candyEatAlready = 0;
       candyEatMaxAmount = 30;
}
    public void GameOver()
    {
        Debug.Log("Game over");
        Time.timeScale = 0f;
    }
    public void WinGame()
    {
        Debug.Log("you win");
        // when the candy thirst have enough candy eaten already,will win the game
        // all the enemy and changed people will back to normal

        //stop spaw enemy 
        EnemyManager.Instance.StopSpawnEnemy();
        //show win menu
        Time.timeScale = 0f;
    }
}
