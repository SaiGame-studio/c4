using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SaiSingleton<InputManager>
{
    protected bool isRightClick = false;

    private void Update()
    {
        this.CheckRightClick();
    }

    protected virtual void CheckRightClick()
    {
        this.isRightClick = Input.GetMouseButton(1);
    }

    public virtual bool IsRightClick()
    {
        return this.isRightClick;
    }
}
