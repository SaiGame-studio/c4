using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SaiSingleton<InputManager>
{
    protected bool isAiming = false;

    protected float attackHold = 0;
    protected float attackLightLimit = 0.5f;
    protected bool isAttackLight = false;
    protected bool isAttackHeavy = false;

    private void Update()
    {
        this.CheckAiming();
        this.CheckAttacking();
    }

    protected virtual void CheckAiming()
    {
        this.isAiming = Input.GetMouseButton(1);
    }

    protected virtual void CheckAttacking()
    {
        if (!this.IsAiming()) return;

        if (Input.GetMouseButton(0)) this.attackHold += Time.deltaTime;

        if (Input.GetMouseButtonUp(0))
        {
            this.isAttackLight = this.attackHold < this.attackLightLimit;
            this.attackHold = 0;
        }
        else
        {
            this.isAttackLight = false;
        }

        if (this.attackHold > this.attackLightLimit) this.isAttackHeavy = true;
        else this.isAttackHeavy = false;
    }

    public virtual bool IsAttackLight()
    {
        return this.isAttackLight;
    }

    public virtual bool IsAttackHeavy()
    {
        return this.isAttackHeavy;
    }

    public virtual bool IsAiming()
    {
        return this.isAiming;
    }
}
