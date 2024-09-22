using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnItemInventory : ButttonAbstract
{
    protected ItemInventory itemInventory;
    public ItemInventory ItemInventory  => itemInventory;

    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }

    protected override void OnClick()
    {
        Debug.Log("Item click");
    }
}
