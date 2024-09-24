using com.cyborgAssets.inspectorButtonPro;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SaiSingleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
        this.LoadItemProfiles();
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

    public virtual InventoryCtrl GetByCodeName(InvCodeName inventoryName)
    {
        foreach (InventoryCtrl inventory in this.inventories)
        {
            if (inventory.GetName() == inventoryName) return inventory;
        }

        return null;
    }

    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
    {
        foreach (ItemProfileSO itemProfile in this.itemProfiles)
        {
            if (itemProfile.itemCode == itemCodeName) return itemProfile;
        }

        return null;
    }

    public virtual InventoryCtrl Monies()
    {
        return this.GetByCodeName(InvCodeName.Monies);
    }

    public virtual InventoryCtrl Items()
    {
        return this.GetByCodeName(InvCodeName.Items);
    }

    public virtual void AddItem(ItemInventory itemInventory)
    {
        InvCodeName invCodeName = itemInventory.ItemProfile.invCodeName;
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(invCodeName);
        inventoryCtrl.AddItem(itemInventory);
    }

    public virtual void AddItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.AddItem(item);
    }

    public virtual void RemoveItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
        ItemInventory item = new(itemProfile, itemCount);
        this.RemoveItem(item);
    }

    public virtual void RemoveItem(ItemInventory itemInventory)
    {
        InvCodeName invCodeName = itemInventory.ItemProfile.invCodeName;
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(invCodeName);
        inventoryCtrl.RemoveItem(itemInventory);
    }

    protected virtual void LoadItemProfiles()
    {
        if (this.itemProfiles.Count > 0) return;
        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
        this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
    }
}
