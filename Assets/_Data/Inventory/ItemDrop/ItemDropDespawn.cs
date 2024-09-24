using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
    public override void DoDespawn()
    {
        ItemDropCtrl itemDropCtrl = (ItemDropCtrl) this.parent;

        ItemInventory item = new();
        item.itemProfile = InventoryManager.Instance.GetProfileByCode(itemDropCtrl.ItemCode);
        item.itemCount = itemDropCtrl.ItemCount;
        InventoryManager.Instance.GetByCodeName(itemDropCtrl.InvCodeName).AddItem(item);

        base.DoDespawn();
    }
}
