using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : SaiMonoBehaviour
{
    [SerializeField] protected int spawnCount = 0;

    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }

    public virtual void Despawn(Transform prefab)
    {
        Destroy(prefab.gameObject);
    }

    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + this.spawnCount;
    }
}
