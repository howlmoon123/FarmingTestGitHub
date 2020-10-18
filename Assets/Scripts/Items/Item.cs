using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [ItemCodeDescription]
    [SerializeField]
    private int _itemCode;

    private SpriteRenderer spriteRenderer;

    public int ItemCode { get { return _itemCode; } set { _itemCode = value; } }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if(ItemCode != 0)
        {
            Init(ItemCode);
        }
    }

    private void Init(int itemCodeParam)
    {
        if(itemCodeParam != 0)
        {
            ItemCode = itemCodeParam;

            ItemsDetails itemsDetails = InventoryManager.Instance.GetItemsDetails(ItemCode);

            spriteRenderer.sprite = itemsDetails.itemSprite;

            if(itemsDetails.itemType == ItemType.Reapable_Scenery)
            {
                gameObject.AddComponent<ItemNudge>();
            }
        }
    }
}
