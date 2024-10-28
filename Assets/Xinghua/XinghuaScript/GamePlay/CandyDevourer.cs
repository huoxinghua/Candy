using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class CandyDevourer : MonoBehaviour,IInteractable
{
  //  [SerializeField] GameObject cameraView;
    private AIEnemy ememy;
    [SerializeField] Image HPBar;
    [SerializeField] Image candyEatBar;
    private bool isDamaged;
    private void Start()
    {
        GameManager.Instance.bossCurrentDurability = GameManager.Instance.maxBossDurability;
        isDamaged = false;
        candyEatBar.fillAmount = Mathf.Clamp(GameManager.Instance.candyEatAlready / GameManager.Instance.candyEatMaxAmount, 0, 1);
        HPBar.fillAmount = Mathf.Clamp(GameManager.Instance.bossCurrentDurability / GameManager.Instance.maxBossDurability, 0, 1);

    }
    public void Interact()
    {
        //Countdown the candy number  
        Inventory.Instance.EatCandy();
        
        GameManager.Instance.currentCookDurability++;
        CheckCandyEaten();
        // this bar show in UI. if the bar is full player will win
        candyEatBar.fillAmount = Mathf.Clamp(GameManager.Instance.candyEatAlready / GameManager.Instance.candyEatMaxAmount, 0, 1);
        //Debug.Log("candyEatAlready is" + GameManager.Instance.candyEatAlready);
        //Debug.Log("candyEatMaxAmount is" + GameManager.Instance.candyEatMaxAmount);


        //increase the cityEntrance Defense Value

    }
    public void CandyDevourerDamaged()
    {
        if (GameManager.Instance.isGameBegining && GameManager.Instance.candyEatAlready <= 0  )
        {
            GameManager.Instance.bossCurrentDurability--;
            
        }
        else if(GameManager.Instance.isGameBegining && GameManager.Instance.candyEatAlready > 0)
        {
            GameManager.Instance.bossCurrentDurability -= 0.2f;
        }
        UIManager.Instance.ShowBossHp();
        HPBar.fillAmount = Mathf.Clamp(GameManager.Instance.bossCurrentDurability / GameManager.Instance.maxBossDurability, 0, 1);
        if (GameManager.Instance.bossCurrentDurability <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
        isDamaged = true;
    }
    private void CheckCandyEaten()
    {
        if (GameManager.Instance.candyEatAlready >= GameManager.Instance.candyEatMaxAmount)
        {
            GameManager.Instance.WinGame();
        }
    }
    public void CandyDevourerDefence()
    {
        // if have candy eaten can defance

    }
    public void ShowKeyToInteract()
    {
        //press e to been feed by player
    }

}
