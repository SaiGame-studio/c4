using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabs : EnemyManagerAbstract
{
    [SerializeField] protected List<EnemyCtrl> prefabs = new();

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyPrefabs();
    }

    protected virtual void LoadEnemyPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        foreach(Transform child in transform)
        {
            EnemyCtrl enemyCtrl = child.GetComponent<EnemyCtrl>();
            if (enemyCtrl) this.prefabs.Add(enemyCtrl);
        }
        Debug.Log(transform.name + ": LoadEnemyPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach(EnemyCtrl enemyCtrl in this.prefabs)
        {
            enemyCtrl.gameObject.SetActive(false);
        }
    }

    public virtual EnemyCtrl GetRandom()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
