using UnityEngine;
using UnityEngine.AI;

public class Projectile2Ctrl : EffectFlyAbtract
{
    [SerializeField] protected DamageSender damageSender;

    public override string GetName()
    {
        return "Projectile2";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        this.damageSender.SetDamage(7);
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }
}
