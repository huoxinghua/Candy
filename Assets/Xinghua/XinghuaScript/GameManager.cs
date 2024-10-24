using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
   public void GameOver()
    {
        Debug.Log("Game over");
        Time.timeScale = 0f;
    }

  

}
