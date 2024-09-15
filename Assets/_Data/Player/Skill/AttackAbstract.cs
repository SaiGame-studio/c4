using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected void Update()
    {
        this.Attacking();
    }

    protected abstract void Attacking();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected virtual AttackPoint GetAttackPoint()
    {
        return this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
    }
}
