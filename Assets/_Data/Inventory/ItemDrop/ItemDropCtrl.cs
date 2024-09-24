using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody _rigi;
    public Rigidbody Rigidbody => _rigi;

    [SerializeField] protected InvCodeName invCodeName = InvCodeName.Items;
    public InvCodeName InvCodeName => invCodeName;

    [SerializeField] protected ItemCode itemCode;
    public ItemCode ItemCode => itemCode;

    [SerializeField] protected int itemCount = 1;
    public int ItemCount => itemCount;

    public override string GetName()
    {
        return "ItemDrop";
    }

    public virtual void SetValue(ItemCode itemCode, int itemCount)
    {
        this.itemCode = itemCode;
        this.itemCount = itemCount;
    }

    public virtual void SetValue(ItemCode itemCode, int itemCount, InvCodeName invCodeName)
    {
        this.itemCode = itemCode;
        this.itemCount = itemCount;
        this.invCodeName = invCodeName;
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
