using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
    [SerializeField] protected ItemInventory playerExp;

    protected override int GetCurrentExp()
    {
        return this.GetPlayerExp().itemCount;
    }

    protected override int DeductExp(int exp)
    {
        return 1;
    }

    protected virtual ItemInventory GetPlayerExp()
    {
        if(this.playerExp == null) this.playerExp = InventoryManager.Instance.Monies().FindItem(ItemCode.PlayerExp);
        return this.playerExp;
    }
}
