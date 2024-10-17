using UnityEngine;

public class SoundSpawnerCtrl : SaiSingleton<SoundSpawnerCtrl>
{
    [SerializeField] protected SoundSpawner spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<SoundSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
}
