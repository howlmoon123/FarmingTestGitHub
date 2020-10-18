
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
       
        Item item = target.GetComponent<Item>();

        if(item != null)
        {
          ItemsDetails details =  InventoryManager.Instance.GetItemsDetails(item.ItemCode);
            Debug.Log("Item Description " + details.itemDescription);
        }
       
    }
}
