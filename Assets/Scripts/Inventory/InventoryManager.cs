
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonobehaviour<InventoryManager>
{

    private Dictionary<int, ItemsDetails> itemDetailsDictionary;

    [SerializeField]
    private SO_Item itemList = null;

    private void Start()
    {
        CreateItemDetailsDictionary();
    }

    /// <summary>
    /// Populates Dictionary from SO_Item
    /// </summary>
    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemsDetails>();
        foreach(ItemsDetails itemsDetails in itemList.itemsDetails)
        {
            itemDetailsDictionary.Add(itemsDetails.itemCode, itemsDetails);
        }

       
    }
    /// <summary>
    /// Get the item from the Dictionary
    /// </summary>
    /// <param name="itemCode"></param>
    /// <returns></returns>
    public ItemsDetails GetItemsDetails(int itemCode)
    {
        ItemsDetails itemsDetails;
        if (itemDetailsDictionary.TryGetValue(itemCode, out itemsDetails))
        {
            return itemsDetails;
        }
        else
            return null;
    }
}
