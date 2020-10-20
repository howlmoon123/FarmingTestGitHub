using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonobehaviour<InventoryManager>
{

    private Dictionary<int, ItemsDetails> itemDetailsDictionary;

    public List<InventoryItem>[] inventoryLists;
    private int[] selectedInventoryItem; // the index of the array is the inventory list, and the value is the item code
    
    // [HideInInspector]
    public int[] inventoryListCapacityIntArray; // the index of the array is the inventory list (from the InventoryLocation enum), and the value is the capacity of that inventory list


    [SerializeField]
    private SO_Item itemList = null;

    protected override void Awake()
    {
        base.Awake();
        // Create Inventory Lists
        CreateInventoryLists();

        CreateItemDetailsDictionary();

        // Initailise selected inventory item array
        selectedInventoryItem = new int[(int)InventoryLocation.count];

        for (int i = 0; i < selectedInventoryItem.Length; i++)
        {
            selectedInventoryItem[i] = -1;
        }

    }

    private void CreateInventoryLists()
    {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.count];

        for (int i = 0; i < (int)InventoryLocation.count; i++)
        {
            inventoryLists[i] = new List<InventoryItem>();
        }
        // initialise inventory list capacity array
        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count];

        // initialise player inventory list capacity
        inventoryListCapacityIntArray[(int)InventoryLocation.player] = Settings.playerInitialInventoryCapacity;
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


    /// <summary>
    /// Add an item to the inventory list for the inventoryLocation and then destroy the gameObjectToDelete
    /// </summary>
    public void AddItem(InventoryLocation inventoryLocation, Item item, GameObject gameObjectToDelete)
    {
        AddItem(inventoryLocation, item);

        Destroy(gameObjectToDelete);
    }

    /// <summary>
    /// Add an item to the inventory list for the inventoryLocation
    /// </summary>
    public void AddItem(InventoryLocation inventoryLocation, Item item)
    {
        int itemCode = item.ItemCode;
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        // Check if inventory already contains the item
        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);

        if (itemPosition != -1)
        {
            AddItemAtPosition(inventoryList, itemCode, itemPosition);
        }
        else
        {
            AddItemAtPosition(inventoryList, itemCode);
        }

        //  Send event that inventory has been updated
        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode)
    {
        InventoryItem inventoryItem = new InventoryItem();

        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQuantity = 1;
        inventoryList.Add(inventoryItem);

      //  DebugPrintInventoryList(inventoryList);
    }

    /*
    private void DebugPrintInventoryList(List<InventoryItem> inventoryList)
    {
        foreach(InventoryItem inventoryItem in inventoryList)
        {
            Debug.Log("Item Descpription " + InventoryManager.Instance.GetItemsDetails(inventoryItem.itemCode).itemDescription + " Quanty " + inventoryItem.itemQuantity);
        }
        Debug.Log("*****************************************************************");
    }
    */
    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int position)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[position].itemQuantity + 1;
        inventoryItem.itemQuantity = quantity;
        inventoryItem.itemCode = itemCode;
        inventoryList[position] = inventoryItem;

      //  DebugPrintInventoryList(inventoryList);
    }

    private int FindItemInInventory(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemCode == itemCode)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Add an item of type itemCode to the inventory list for the inventoryLocation
    /// </summary>
    public void AddItem(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        // Check if inventory already contains the item
        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);

        if (itemPosition != -1)
        {
            AddItemAtPosition(inventoryList, itemCode, itemPosition);
        }
        else
        {
            AddItemAtPosition(inventoryList, itemCode);
        }

        //  Send event that inventory has been updated
        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    /// <summary>
    /// Set the selected inventory item for inventoryLocation to itemCode
    /// </summary>
    public void SetSelectedInventoryItem(InventoryLocation inventoryLocation, int itemCode)
    {
        selectedInventoryItem[(int)inventoryLocation] = itemCode;
    }

}
