using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateHP : Gate
{
    [SerializeField] Image HPBar;
    public GateHP() : base() { }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = Mathf.Clamp((pushThreshold - pushCount) / pushThreshold, 0, 1);
    }
}
