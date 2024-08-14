using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : SaiMonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }
}
