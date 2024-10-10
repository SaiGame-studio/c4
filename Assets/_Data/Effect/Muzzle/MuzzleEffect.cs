using UnityEngine;
using UnityEngine.AI;

public class MuzzleEffect : SaiMonoBehaviour
{
    [SerializeField] protected MuzzleCode muzzle;

    protected virtual void OnEnable()
    {
        this.SpawnMuzzle();
    }

    protected virtual void SpawnMuzzle()
    {
        if (this.muzzle == MuzzleCode.NoMuzzle) return;
        EffectSpawner effectSpawner = EffectSpawnerCtrl.Instance.Spawner;
        EffectCtrl prefab = effectSpawner.PoolPrefabs.GetByName(this.muzzle.ToString());
        EffectCtrl newEffect = effectSpawner.Spawn(prefab, transform.position);
        newEffect.gameObject.SetActive(true);
    }
}
