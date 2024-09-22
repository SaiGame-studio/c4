using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : SaiMonoBehaviour
{
    [SerializeField] protected List<ItemInventory> items = new();
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

    public virtual bool RemoveItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItemNotEmpty(item.itemProfile.itemCode);
        if (itemExist == null) return false;
        if (itemExist.itemCount < item.itemCount) return false;
        itemExist.itemCount -= item.itemCount;
        if (itemExist.itemCount == 0) this.items.Remove(itemExist);
        return true;
    }

    public virtual ItemInventory FindItem(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode == itemCode) return itemInventory;
        }

        return null;
    }

    public virtual ItemInventory FindItemNotEmpty(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            if (itemInventory.itemCount > 0) return itemInventory;
        }

        return null;
    }
}
