using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateHP : Gate
{
    [SerializeField] private int currentHP;
    [SerializeField] private int maxHP;
    [SerializeField] Image HPBar;
    public GateHP() : base() { }
    // Start is called before the first frame update
    void Start()
    {
        currentHP = pushThreshold - pushCount;
        maxHP = pushThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = Mathf.Clamp(currentHP / maxHP, 0, 1);
    }
}
