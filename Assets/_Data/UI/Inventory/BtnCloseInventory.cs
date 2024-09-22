using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInventory : ButttonAbstract
{
    public virtual void CloseInventoryUI()
    {
        InventoryUI.Instance.Hide();
    }

    protected override void OnClick()
    {
        this.CloseInventoryUI();
    }
}
