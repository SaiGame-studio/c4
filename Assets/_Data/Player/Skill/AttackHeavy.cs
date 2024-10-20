using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    protected string effectName = "Projectile3";
    protected float timer = 0;
    protected float delay = 0.1f;
    protected SoundName shootSfxName = SoundName.LaserOneShoot;


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

        this.SpawnSound(effectFly.transform.position);
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }

    protected virtual void SpawnSound(Vector3 position)
    {
        SFXCtrl sfxPrefab = (SFXCtrl)SoundSpawnerCtrl.Instance.Prefabs.GetByName(this.shootSfxName.ToString());
        SFXCtrl newSfx = (SFXCtrl)SoundSpawnerCtrl.Instance.Spawner.Spawn(sfxPrefab, position);
        newSfx.gameObject.SetActive(true);
    }
}
