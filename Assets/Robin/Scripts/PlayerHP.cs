using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float MaxHP = 100;
    [SerializeField] float currentHP;
    [SerializeField] Image HPBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = Mathf.Clamp(currentHP/MaxHP, 0, 1);
    }
}
