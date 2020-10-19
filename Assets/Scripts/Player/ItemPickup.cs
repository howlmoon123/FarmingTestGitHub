
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
       
        Item item = target.GetComponent<Item>();

        if(item != null)
        {
          ItemsDetails details =  InventoryManager.Instance.GetItemsDetails(item.ItemCode);
          if(details.canBePickedUp)
            {
                // Add item to inventory
                InventoryManager.Instance.AddItem(InventoryLocation.player, item, target.gameObject);

                // Play pick up sound
              //  AudioManager.Instance.PlaySound(SoundName.effectPickupSound);

            }
        }
       
    }
}
