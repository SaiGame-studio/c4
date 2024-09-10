using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SaiSingleton<InputManager>
{
    protected bool isLeftClick = false;
    protected bool isRightClick = false;

    private void Update()
    {
        this.CheckRightClick();
    }

    protected virtual void CheckRightClick()
    {
        this.isLeftClick = Input.GetMouseButton(0);
        this.isRightClick = Input.GetMouseButton(1);
    }

    public virtual bool IsLeftClick()
    {
        return this.isLeftClick;
    }

    public virtual bool IsRightClick()
    {
        return this.isRightClick;
    }
}
