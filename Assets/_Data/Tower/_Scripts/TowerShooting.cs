using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyCtrl target;

    protected void FixedUpdate()
    {
        this.LookAtTarget();
        //this.ShootAtTarget();
    }

    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;
        this.towerCtrl.Rotator.LookAt(this.target.TowerTargetable.transform.position);
    }
}
