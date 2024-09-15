using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SaiSingleton<InputManager>
{
    protected bool isAttackLight = false;
    protected bool isAiming = false;

    private void Update()
    {
        this.CheckAiming();
        this.CheckAttackLight();
    }

    protected virtual void CheckAiming()
    {
        this.isAiming = Input.GetMouseButton(1);
    }

    protected virtual void CheckAttackLight()
    {
        this.isAttackLight = Input.GetMouseButtonUp(0);
    }

    public virtual bool IsAttackLight()
    {
        return this.isAttackLight;
    }

    public virtual bool IsAiming()
    {
        return this.isAiming;
    }
}
