using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnerCtrl : SaiSingleton<EffectSpawnerCtrl>
{
    [SerializeField] protected EffectSpawner spawner;
    public EffectSpawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
    }

    protected virtual void LoadEffectSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EffectSpawner>();
        Debug.Log(transform.name + ": LoadEffectSpawner", gameObject);
    }

}
