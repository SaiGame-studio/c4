using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn<T> : SaiMonoBehaviour
{
    [SerializeField] protected T parent;
    [SerializeField] protected Spawner<T> spawner;
    [SerializeField] protected float timeLife = 7f;
    [SerializeField] protected float currentTime = 7f;

    protected virtual void FixedUpdate()
    {
        this.DespawnChecking();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadParent();
    }

    protected virtual void LoadParent()
    {
        if (this.parent != null) return;
        this.parent = transform.parent.GetComponent<T>();
        Debug.Log(transform.name + ": LoadParent", gameObject);
    }

    public virtual void SetSpawner(Spawner<T> spawner)
    {
        this.spawner = spawner;
    }

    protected virtual void DespawnChecking()
    {
        this.currentTime -= Time.fixedDeltaTime;
        if (this.currentTime > 0) return;

        this.spawner.Despawn(this.parent);
        this.currentTime = this.timeLife;
    }
}
