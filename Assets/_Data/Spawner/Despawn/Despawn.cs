using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : SaiMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected float timeLife = 7f;
    [SerializeField] protected float currentTime = 7f;

    protected virtual void FixedUpdate()
    {
        this.DespawnChecking();
    }

    public virtual void SetSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }

    protected virtual void DespawnChecking()
    {
        this.currentTime -= Time.fixedDeltaTime;
        if (this.currentTime > 0) return;

        this.spawner.Despawn(transform.parent);
        this.currentTime = this.timeLife;
    }
}
