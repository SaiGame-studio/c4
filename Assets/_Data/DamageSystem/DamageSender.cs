using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    protected virtual void Send(DamageRecever damageRecever)
    {
        damageRecever.Deduct(this.damage);
    }
}
