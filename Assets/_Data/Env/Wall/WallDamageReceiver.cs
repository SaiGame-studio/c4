using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WallDamageReceiver : DamageRecever
{
    [SerializeField] protected BoxCollider boxCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = false;
        Debug.Log(transform.name + ": LoadBoxCollider", gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isImmotal = true;
    }
}
