using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDropManager : SaiSingleton<ItemsDropManager>
{
    [SerializeField] protected ItemsDropSpawner spawner;
    public ItemsDropSpawner Spawner => spawner;

    public float spawnHeight = 1.0f;
    public float forceAmount = 5.0f;

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

    public virtual void Drop(ItemCode itemCode, int dropCoint, Vector3 dropPosition)
    {
        Vector3 spawnPosition = dropPosition + new Vector3(0, spawnHeight, 0);
        ItemDropCtrl itemPrefab = this.spawner.PoolPrefabs.GetByName("Gold");

        ItemDropCtrl newItem = this.spawner.Spawn(itemPrefab, spawnPosition);
        newItem.gameObject.SetActive(true);

        Vector3 randomDirection = Random.onUnitSphere; 
        randomDirection.y = Mathf.Abs(randomDirection.y);
        newItem.Rigidbody.AddForce(randomDirection * forceAmount, ForceMode.Impulse);
        
        //Make that item value 
    }
}

