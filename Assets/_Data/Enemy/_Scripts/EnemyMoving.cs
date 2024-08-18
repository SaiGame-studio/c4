using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : SaiMonoBehaviour
{
    public GameObject target;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected int pathIndex = 0;
    [SerializeField] protected Path enemyPath;

    protected override void Start()
    {
        this.LoadEnemyPath();
    }

    void FixedUpdate()
    {
        this.Moving();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadTarget();
    }


    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("TargetMoving");
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }

    protected virtual void Moving()
    {
        this.enemyCtrl.Agent.SetDestination(target.transform.position);
    }

    protected virtual void LoadEnemyPath()
    {
        if (this.enemyPath != null) return;
        this.enemyPath = PathsManager.Instance.GetPath(this.pathIndex);
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
}
