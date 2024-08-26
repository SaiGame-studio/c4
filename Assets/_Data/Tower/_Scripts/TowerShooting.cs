using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    protected float speedFinding = 1f;
    protected float rotationSpeed = 200f;
    [SerializeField] protected EnemyCtrl target;

    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
    }

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetFinding), this.speedFinding);
    }

    protected virtual void TargetFinding()
    {
        Invoke(nameof(this.TargetFinding), this.speedFinding);

        if (this.target != this.towerCtrl.TowerTargeting.Nearest) this.target = null;

        if (this.target != null) return;
        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }

    protected virtual void LookAtTarget()
    {
        //float currentTime = Mathf.Round(Time.time);
        //Debug.Log("currentTime: " + currentTime);

        if (this.target == null) return;

        this.towerCtrl.TowerRotator.LookAt(this.target.TowerTargetable.transform.position);
    }
}
