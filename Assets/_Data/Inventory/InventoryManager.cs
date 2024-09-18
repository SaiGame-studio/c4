using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SaiSingleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
    }

    protected override void Start()
    {
        base.Start();
        this.AddTestItems();
    }

    protected virtual void AddTestItems()
    {
        InventoryCtrl inventoryCtrl = this.inventories[0];

        ItemInventory item = new ItemInventory();
        item.itemName = "Gold";
        item.itemCount = 11;

        inventoryCtrl.AddItem(item);

        ItemInventory item2 = new ItemInventory();
        item2.itemName = "Gold";
        item2.itemCount = 2;
        inventoryCtrl.AddItem(item2);
    }

    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach (Transform child in transform)
        {
            InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
            if (inventoryCtrl == null) continue;
            this.inventories.Add(inventoryCtrl);
        }
        Debug.Log(transform.name + ": LoadInventories", gameObject);
    }

}
