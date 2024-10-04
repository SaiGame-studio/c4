using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : SaiMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected string pathName = "path_0";
    [SerializeField] protected Path enemyPath;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float stopDistance = 1f;
    [SerializeField] protected bool canMove = true;
    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected bool isFinish = false;

    protected virtual void OnEnable()
    {
        this.OnReborn();
    }

    protected override void Start()
    {
        this.LoadEnemyPath();
    }

    void FixedUpdate()
    {
        this.Moving();
        this.CheckMoving();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }


    protected virtual void Moving()
    {

        if (!this.canMove)
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }

        if (this.enemyCtrl.EnemyDamageRecevier.IsDead())
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }

        this.FindNextPoint();

        if (this.currentPoint == null || this.isFinish == true)
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }

        this.enemyCtrl.Agent.isStopped = false;
        this.enemyCtrl.Agent.SetDestination(this.currentPoint.transform.position);
    }

    protected virtual void FindNextPoint()
    {
        if(this.currentPoint == null) this.currentPoint = this.enemyPath.GetPoint(0);

        this.pointDistance = Vector3.Distance(transform.position, this.currentPoint.transform.position);
        if(this.pointDistance < this.stopDistance)
        {
            this.currentPoint = this.currentPoint.NextPoint;
            if (this.currentPoint == null) this.isFinish = true;
        }
    }

    protected virtual void LoadEnemyPath()
    {
        if (this.enemyPath != null) return;
        this.enemyPath = PathsManager.Instance.GetPath(this.pathName);
        //Debug.Log(transform.name + ": LoadEnemyPath", gameObject);
    }

    protected virtual void CheckMoving()
    {
        if (this.enemyCtrl.Agent.velocity.magnitude > 0.1f) this.isMoving = true;
        else this.isMoving = false;

        this.enemyCtrl.Animator.SetBool("isMoving", this.isMoving);
    }

    protected virtual void OnReborn()
    {
        this.isFinish = false;
        this.currentPoint = null;
    }
}
