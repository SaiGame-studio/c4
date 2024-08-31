using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = this.model.Find("Rotator");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadTowerTargeting()
    {
        if (this.towerTargeting != null) return;
        this.towerTargeting = transform.GetComponentInChildren<TowerTargeting>();
        Debug.Log(transform.name + ": LoadTowerTargeting", gameObject);
    }
}
