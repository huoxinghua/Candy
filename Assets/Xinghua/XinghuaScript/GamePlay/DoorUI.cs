using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class DoorUI : Singleton<DoorUI>
{
    [SerializeField] Image HPBar;
    [SerializeField] private CityEntrance cityEntrance;
    void Start()
    {
       cityEntrance = gameObject.GetComponent<CityEntrance>();
        // currentPushThreshold = pushThreshold;
        Debug.Log("cityEntrance" + cityEntrance);
    }

    private void Update()
    {
      
        HPBar.fillAmount = Mathf.Clamp(cityEntrance.currentPushThreshold / cityEntrance.pushThreshold, 0, 1);
     
    }
    

}
