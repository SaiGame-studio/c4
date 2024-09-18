using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    protected string effectName = "Fire2";
    protected float timer = 0;
    protected float delay = 0.1f;

    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackHeavy()) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        AttackPoint attackPoint = this.GetAttackPoint();
        EffectCtrl effect = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);

        EffectFlyAbtract effectFly = (EffectFlyAbtract)effect;
        effectFly.FlyToTarget.SetTarget(this.playerCtrl.CrosshairPointer.transform);

        effect.gameObject.SetActive(true);
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }
}
