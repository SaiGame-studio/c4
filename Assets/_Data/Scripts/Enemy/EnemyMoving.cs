using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        agent.SetDestination(target.transform.position);
    }
}
