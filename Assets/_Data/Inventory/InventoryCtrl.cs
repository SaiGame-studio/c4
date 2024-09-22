using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : SaiMonoBehaviour
{
    protected List<ItemInventory> items = new();
    public List<ItemInventory> Items => items;

    public abstract InvCodeName GetName();

    public virtual void AddItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItem(item.itemProfile.itemCode);
        if (!item.itemProfile.isStackable || itemExist == null)
        {
            item.itemId = Random.Range(0, 999999999);
            this.items.Add(item);
            return;
        }

        itemExist.itemCount += item.itemCount;
    }

    public virtual ItemInventory FindItem(ItemCode itemCode)
    {
        foreach(ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode == itemCode) return itemInventory;
        }

        return null;
    }
}
