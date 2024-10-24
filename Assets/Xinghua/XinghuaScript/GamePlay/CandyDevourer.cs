using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CandyDevourer : MonoBehaviour,IInteractable
{
  //  [SerializeField] GameObject cameraView;
    private AIEnemy ememy;
   
    private bool isDamaged;
    private void Start()
    {
        GameManager.Instance.currentDurability = GameManager.Instance.maxDurability;
        isDamaged = false;   
    }
    public void Interact()
    {
        //Countdown the candy number  
        Inventory.Instance.UseCandy();
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
        
    }


}
