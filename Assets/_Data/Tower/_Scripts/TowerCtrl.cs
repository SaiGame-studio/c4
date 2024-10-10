using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;

    [SerializeField] protected TowerShooting towerShooting;
    public TowerShooting TowerShooting => towerShooting;

    [SerializeField] protected LevelAbstract level;
    public LevelAbstract Level => level;

    [SerializeField] protected List<FirePoint> firePoints = new();
    public List<FirePoint> FirePoints => firePoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadFirePoints();
        this.LoadTowerShootings();
        this.LoadLevel();
    }

    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = GetComponentInChildren<LevelAbstract>();
        Debug.Log(transform.name + ": LoadLevel", gameObject);
    }

    protected virtual void LoadTowerShootings()
    {
        if (this.towerShooting != null) return;
        this.towerShooting = GetComponentInChildren<TowerShooting>();
        Debug.Log(transform.name + ": LoadTowerShootings", gameObject);
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
        this.towerTargeting.transform.localPosition = new Vector3(0, 1, 0);
        Debug.Log(transform.name + ": LoadTowerTargeting", gameObject);
    }

    protected virtual void LoadFirePoints()
    {
        if (this.firePoints.Count > 0) return;
        FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.Log(transform.name + ": LoadTowerTargeting", gameObject);
    }
}
