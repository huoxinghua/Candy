using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private GameObject itemUI;
    [SerializeField] private TMP_Text appleText;
    [SerializeField] private TMP_Text bananaText;
    [SerializeField] private TMP_Text candyText;
    private void Update()
    {
        UpdateInventoryUI();
    }
    private void UpdateInventoryUI()
    {
        candyText.text ="Candy" + Inventory.Instance.collectedItems["Candy"].ToString();
        appleText.text = "Apple" + Inventory.Instance.collectedItems["Apple"].ToString();
        bananaText.text = "Banana" + Inventory.Instance.collectedItems["Banana"].ToString();

    }
}
