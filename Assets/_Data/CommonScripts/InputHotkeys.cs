using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotkeys : SaiSingleton<InputHotkeys>
{
    protected bool isToogleInventoryUI = false;
    public bool IsToogleInventoryUI => isToogleInventoryUI;

    public bool isToogleMusic = false;

    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleMusic();
    }

    protected virtual void OpenInventory()
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleMusic()
    {
        this.isToogleMusic = Input.GetKeyUp(KeyCode.M);
    }
}
