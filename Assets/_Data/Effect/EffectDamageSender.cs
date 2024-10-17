using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class EffectDamageSender : DamageSender
{
    [SerializeField] protected EffectCtrl effectCtrl;
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadEffectCtrl();
    }

    protected virtual void LoadEffectCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = transform.GetComponentInParent<EffectCtrl>();
        Debug.Log(transform.name + ": LoadEffectCtrl", gameObject);
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.05f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected override void Send(DamageReceiver damageReceiver, Collider collider)
    {
        base.Send(damageReceiver, collider);
        this.ShowHitEffect(collider);
        this.effectCtrl.Despawn.DoDespawn();
    }

    protected virtual void ShowHitEffect(Collider collider)
    {
        Vector3 hitPoint = collider.ClosestPoint(transform.position);
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName(this.GetHitName());
        EffectCtrl newObj = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, hitPoint);
        newObj.gameObject.SetActive(true);
    }

    protected abstract string GetHitName();
}
