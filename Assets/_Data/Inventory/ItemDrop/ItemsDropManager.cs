using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDropManager : SaiSingleton<ItemsDropManager>
{
    [SerializeField] protected ItemsDropSpawner spawner;
    public ItemsDropSpawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<ItemsDropSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    public virtual void Drop(ItemCode itemCode, int dropCoint)
    {
        //Create Item from Pool
        //Make that item value
    }
}
