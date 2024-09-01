using UnityEngine;

public abstract class PoolObj : SaiMonoBehaviour 
{
    [SerializeField] protected DespawnBase despawn;
    public DespawnBase Despawn => despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DespawnBase>();
        //this.despawn = transform.GetComponentInChildren<BulletDespawn>();
        //this.despawn = transform.GetComponentInChildren<Despawn<Bullet>>();
        //this.despawn = transform.GetComponentInChildren<Despawn<T>>();
        //this.despawn = transform.GetComponentInChildren<SaiMonoBehaviour>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
}
