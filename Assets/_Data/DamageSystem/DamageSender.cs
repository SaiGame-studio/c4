using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected int damage = 1;

    public virtual void OnTriggerEnter(Collider collider)
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

    public virtual void SetDamage(int newDamage)
    {
        this.damage = newDamage;
    }
}
