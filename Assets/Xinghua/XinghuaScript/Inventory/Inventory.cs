using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    private int currentItemCount;
    Dictionary<string,int> collectedItems = new Dictionary<string,int>();
    private void Start()
    {
        InitializeItem();
    }
    private void InitializeItem()
    {
        AddItem("Candy",0);
        AddItem("Apple", 0);
        AddItem("Banana", 0);
    }
    public void AddItem(string itemName, int value)
    {
        if (collectedItems.ContainsKey(itemName))
        {
            //if the item in the dictionary,just add value
            collectedItems[itemName] += value;
        }
        else
        {
             collectedItems.Add(itemName, value);
        }
        Debug.Log($"Added {value} {itemName}. Now you have {collectedItems[itemName]} {itemName}");
        
    }
    private void RemoveItem(string itemName,int value) 
    {
        if (collectedItems.ContainsKey(itemName) && collectedItems[itemName] >= value)
        {
            collectedItems[itemName] -= value;
        }
        else
        {
            Debug.Log("Please collect more apple or banana");
        }
        //when use need remove
    }
    private void CookCandy()
    {
       
        //apple + banana can make candy
        RemoveItem("Apple",2);
        RemoveItem("Banana", 1);
        AddItem("Candy",1);
    }
    public void UseCandy()
    {
        Debug.Log("Use candy");
        if (collectedItems.ContainsKey("Candy")&& collectedItems["Candy"]>0)
        {
            RemoveItem("Candy", 1);
        }
        else if (collectedItems.ContainsKey("Apple") && collectedItems["Apple"] >= 2 &&
           collectedItems.ContainsKey("Banana") && collectedItems["Banana"] >= 1)
        {
            CookCandy(); 
            Debug.Log("Candy cooked successfully.");
            UseCandy(); 
        }
        else
        {
            Debug.Log("Not enough ingredients to cook Candy.");
        }
        Debug.Log("Now you have Candy" + collectedItems["Candy"]);
    }
    

}
