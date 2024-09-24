using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : SaiMonoBehaviour where T : PoolObj
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected Transform poolHolder;
    [SerializeField] protected List<T> inPoolObjs = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoolHolder();
    }

    protected virtual void LoadPoolHolder()
    {
        if (this.poolHolder != null) return;
        this.poolHolder = transform.Find("PoolHolder");
        if (this.poolHolder == null)
        {
            this.poolHolder = new GameObject("PoolHolder").transform;
            this.poolHolder.parent = transform;
        }
        Debug.Log(transform.name + ": LoadPoolHolder", gameObject);
    }

    public virtual T Spawn(T prefab)
    {

        T newObject = this.GetObjFromPool(prefab);
        if (newObject == null)
        {
            newObject = Instantiate(prefab);
            this.spawnCount++;
            this.UpdateName(prefab.transform, newObject.transform);
        }

        if (this.poolHolder != null) newObject.transform.parent = this.poolHolder.transform;

        return newObject;
    }

    public virtual T Spawn(T buletPrefab, Vector3 postion)
    {
        T newBullet = this.Spawn(buletPrefab);
        newBullet.transform.position = postion;
        return newBullet;
    }

    public virtual void Despawn(Transform obj)
    {
        Destroy(obj.gameObject);
    }

    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }

    protected virtual void RemoveObjectFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }

    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + this.spawnCount;
    }

    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (T inPoolObj in this.inPoolObjs )
        {
            if (prefab.GetName() == inPoolObj.GetName())
            {
                this.RemoveObjectFromPool(inPoolObj);
                return inPoolObj;
            }
        }

        return null;
    }
}
