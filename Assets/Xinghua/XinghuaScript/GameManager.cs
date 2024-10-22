using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int bananaCount = 0;
    private int appleCount = 0 ;
    private int candyCount = 0;


    [SerializeField] private int pushThreshold = 10;

    public void AddItemCount()
    {

        Debug.Log("candy  count is " + candyCount);
        candyCount++;
        bananaCount++;
        appleCount++;
        Debug.Log("bananaCount  count is " + bananaCount);
        Debug.Log("appleCount  count is " + appleCount);
    }
    public void CookCandy()
    {
        candyCount--;
        bananaCount--;
        candyCount++;
    }
    public void FeedCandy()
    {
        Debug.Log("I am happy wall is stronger now");
        candyCount--;
        pushThreshold += 5;
    }

}
