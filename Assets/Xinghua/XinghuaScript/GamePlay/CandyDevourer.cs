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
    private bool isDamaged;
    private void Start()
    {
        GameManager.Instance.currentDurability = GameManager.Instance.maxDurability;
        isDamaged = false;
        GameManager.Instance.candyEnergy = 0;
        HPBar.fillAmount = Mathf.Clamp(GameManager.Instance.candyEatAlready / GameManager.Instance.candyEatMaxAmount, 0, 1);
    }
    public void Interact()
    {
        //Countdown the candy number  
        Inventory.Instance.EatCandy();
        CheckCandyEaten();
        HPBar.fillAmount = Mathf.Clamp(GameManager.Instance.candyEatAlready/ GameManager.Instance.candyEatMaxAmount, 0, 1);
        Debug.Log("candyEatAlready is" + GameManager.Instance.candyEatAlready);
        Debug.Log("candyEatMaxAmount is" + GameManager.Instance.candyEatMaxAmount);


        //increase the cityEntrance Defense Value

        // CameraManager.Instance.ActiveSoloCamera(cameraView, true);
    }
    public void CandyDevourerDamaged()
    {
        GameManager.Instance.currentDurability--;
       
        if (GameManager.Instance.currentDurability <= 0)
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

    }
    public void ShowKeyToInteract()
    {

    }

}
