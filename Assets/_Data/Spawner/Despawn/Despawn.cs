using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn<T> : DespawnBase where T : PoolObj
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
        this.LoadSpawner();
    }

    protected virtual void LoadParent()
    {
        if (this.parent != null) return;
        this.parent = transform.parent.GetComponent<T>();
        Debug.Log(transform.name + ": LoadParent", gameObject);
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GameObject.FindAnyObjectByType<Spawner<T>>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void DespawnChecking()
    {
        this.currentTime -= Time.fixedDeltaTime;
        if (this.currentTime > 0) return;

        this.spawner.Despawn(this.parent);
        this.currentTime = this.timeLife;
    }
}
