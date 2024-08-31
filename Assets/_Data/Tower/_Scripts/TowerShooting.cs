using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected float targetLoadSpeed = 1f;
    [SerializeField] protected float shootSpeed = 1f;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected BulletSpawner bulletSpawner;
    [SerializeField] protected Bullet bullet;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        Invoke(nameof(this.Shooting), this.shootSpeed);
    }

    protected void FixedUpdate()
    {
        this.Looking();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);

        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;
        Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerCtrl.Rotator.forward,
            directionToTarget,
            rotationSpeed * Time.fixedDeltaTime,
            0.0f
        );

        // Apply the new direction to the rotator
        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);

        //this.towerCtrl.Rotator.LookAt(this.target.TowerTargetable.transform.position);
    }

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), this.shootSpeed);
        if (this.target == null) return;
        this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet);
    }
}
