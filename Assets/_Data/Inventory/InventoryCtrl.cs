using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : SaiMonoBehaviour
{
    protected List<ItemInventory> items = new();

    public abstract string GetName();

    public virtual void AddItem(ItemInventory item)
    {
        this.items.Add(item);
    }
}
