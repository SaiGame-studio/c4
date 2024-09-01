using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter: " + collider.name);
    }

    protected virtual void Send(DamageRecever damageRecever)
    {
        damageRecever.Deduct(this.damage);
    }
}
