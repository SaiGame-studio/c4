using com.cyborgAssets.inspectorButtonPro;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTester : SaiMonoBehaviour
{
    protected override void Start()
    {
        base.Start();
        this.AddTestGold(1000);
    }

    [ProButton]
    public virtual void AddTestGold(int count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(InvCodeName.Monies);

        ItemInventory gold = new();
        gold.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
        gold.itemName = gold.itemProfile.itemName;
        gold.itemCount = count;
        inventoryCtrl.AddItem(gold);
    }

    [ProButton]
    public virtual void RemoveTestGold(int count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(InvCodeName.Monies);

        ItemInventory gold = new();
        gold.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
        gold.itemName = gold.itemProfile.itemName;
        gold.itemCount = count;
        inventoryCtrl.RemoveItem(gold);
    }

    [ProButton]
    public virtual void AddTestItems(ItemCode itemCode, int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByCodeName(InvCodeName.Items);
        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new();
            wand.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            wand.itemName = wand.itemProfile.itemName;
            wand.itemCount = 1;
            items.AddItem(wand);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(ItemCode itemCode, int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByCodeName(InvCodeName.Items);
        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new();
            wand.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            wand.itemName = wand.itemProfile.itemName;
            wand.itemCount = 1;
            items.RemoveItem(wand);
        }
    }
}
