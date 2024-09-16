using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected string effectName = "Fire1";

    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;
        AttackPoint attackPoint = this.GetAttackPoint();
        EffectCtrl effect = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);
        effect.gameObject.SetActive(true);
        Debug.Log("Light Attack");
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }
}
