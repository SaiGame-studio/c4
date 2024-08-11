using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySort : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();
    EnemyManager enemyManager;

    void Awake()
    {
        this.LoadComponents();
    }

    private void Reset()
    {
        this.LoadComponents();
    }

    void Start()
    {
        this.Sorting();
    }

    protected virtual void LoadComponents()
    {
        if (this.enemyManager != null) return;
        this.enemyManager = GetComponent<EnemyManager>();
        Debug.Log(transform.name + ": LoadComponents");
    }

    protected virtual void Sorting()
    {
        this.enemies = this.enemyManager.Enemies;


    }
}
