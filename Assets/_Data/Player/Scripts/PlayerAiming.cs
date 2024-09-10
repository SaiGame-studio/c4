using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
    protected float closeLookDistance = 0.6f;
    protected float farLookDistance = 1.3f;
    private void Update()
    {
        this.Aiming();
    }

    protected virtual void Aiming()
    {
        if (InputManager.Instance.IsRightClick()) this.LookClose();
        else this.LookFar();
    }

    protected virtual void LookClose()
    {
        this.playerCtrl.ThirdPersonCamera.defaultDistance = this.closeLookDistance;
    }

    protected virtual void LookFar()
    {
        this.playerCtrl.ThirdPersonCamera.defaultDistance = this.farLookDistance;
    }
}
