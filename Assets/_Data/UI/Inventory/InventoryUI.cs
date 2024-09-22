using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    protected bool IsShow => isShow;

    [SerializeField] protected BtnItemInventory defaultItemInventoryUI;
    protected List<BtnItemInventory> btnItems = new();

    protected virtual void FixedUpdate()
    {
        this.ItemUpdating();
    }

    protected override void Start()
    {
        base.Start();
        this.Show();
        this.HideDefaultItemInventory();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
    }

    protected virtual void LoadBtnItemInventory()
    {
        if (this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
    }

    public virtual void Show()
    {
        this.isShow = true;
        gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }

    protected virtual void ItemUpdating()
    {
        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();

        foreach (ItemInventory itemInventory in itemInvCtrl.Items)
        {
            BtnItemInventory newBtnItem = this.GetExistItem(itemInventory);
            if (newBtnItem == null)
            {
                newBtnItem = Instantiate(this.defaultItemInventoryUI);
                newBtnItem.transform.SetParent(this.defaultItemInventoryUI.transform.parent);
                newBtnItem.SetItem(itemInventory);
                newBtnItem.transform.localScale = new Vector3(1, 1, 1);
                newBtnItem.gameObject.SetActive(true);
                newBtnItem.name = itemInventory.itemName + "-" + itemInventory.itemId;
                this.btnItems.Add(newBtnItem);
            }
        }
    }

    protected virtual BtnItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach (BtnItemInventory itemInvUI in this.btnItems)
        {
            if (itemInvUI.ItemInventory.itemId == itemInventory.itemId) return itemInvUI;
        }
        return null;
    }
}

