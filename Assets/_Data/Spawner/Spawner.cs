using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : SaiMonoBehaviour
{
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }

    public virtual void Despawn(Transform prefab)
    {
        Destroy(prefab.gameObject);
    }
}
