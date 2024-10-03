using UnityEngine;
using UnityEngine.AI;

public class EnemyHp : SliderHp
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override float GetValue()
    {
        return (float)this.enemyCtrl.EnemyDamageRecevier.CurrentHp / (float)this.enemyCtrl.EnemyDamageRecevier.MaxHP;
    }
}
