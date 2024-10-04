using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float targetLoadSpeed = 1f;
    [SerializeField] protected float shootSpeed = 0.2f;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl target;

    [SerializeField] protected int killCount = 0;
    [SerializeField] protected int totalKill = 0;
    public int KillCount => killCount;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        Invoke(nameof(this.Shooting), this.shootSpeed);
    }

    protected void FixedUpdate()
    {
        this.Looking();
        this.IsTargetDead();
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

        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
    }

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), this.shootSpeed);
        if (this.target == null) return;

        FirePoint firePoint = this.GetFirePoint();
        Vector3 rotatorDirection = this.towerCtrl.Rotator.transform.forward;

        this.SpawnBullet(firePoint.transform.position, rotatorDirection);
        this.SpawnMuzzle(firePoint.transform.position, rotatorDirection);
    }

    protected virtual void SpawnBullet(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        Bullet newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, spawnPoint);
        newBullet.transform.forward = rotatorDirection;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual void SpawnMuzzle(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        EffectCtrl effect = EffectSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName("Muzzle1");
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(effect, spawnPoint);
        newEffect.transform.forward = rotatorDirection;
        newEffect.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerCtrl.FirePoints[this.currentFirePoint];
        this.currentFirePoint++;
        if (this.currentFirePoint == this.towerCtrl.FirePoints.Count) this.currentFirePoint = 0;
        return firePoint;
    }

    protected virtual bool IsTargetDead()
    {
        if (this.target == null) return true;
        if (!this.target.EnemyDamageRecevier.IsDead()) return false;
        this.killCount++;
        this.totalKill++;
        this.target = null;
        return true;
    }

    public virtual bool DeductKillCount(int count)
    {
        if (this.killCount < count) return false;
        this.killCount -= count;
        return true;
    }
}







