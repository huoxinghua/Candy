using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceUI : Singleton<WorldSpaceUI>
{
    [SerializeField] private HpBar[] image;
    [SerializeField] string hpBarName;
    [SerializeField] private GameObject hpBar;


    private void Start()
    {
        hpBar.SetActive(false);
    }
    public void ShowBossHp()
    {
        
       hpBar.SetActive(true);
    }
  

}
