using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody _rigi;
    public Rigidbody Rigidbody => _rigi;

    public override string GetName()
    {
        return "ItemDrop";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigi != null) return;
        this._rigi = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }
}
