
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_itemList", menuName = "Item/Item_List")]
public class SO_Item : ScriptableObject
{
    [SerializeField]
    public List<ItemsDetails> itemsDetails = new List<ItemsDetails>();
}
