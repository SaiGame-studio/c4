using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;

    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;

    [SerializeField] protected TowerShooting towerShooting;
    public TowerShooting TowerShooting => towerShooting;

    [SerializeField] protected LevelAbstract level;
    public LevelAbstract Level => level;

    protected string bulletName = "Bullet";
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;

    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => bulletPrefabs;

    [SerializeField] protected List<FirePoint> firePoints = new();
    public List<FirePoint> FirePoints => firePoints;


    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        this.LoadBulletPrefabs();
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

    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = FindObjectOfType<BulletSpawner>();
        Debug.Log(transform.name + ": LoadBulletSpawner", gameObject);
    }

    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = this.bulletPrefabs.GetByName(this.bulletName);
        Debug.Log(transform.name + ": LoadBullet", gameObject);
    }

    protected virtual void LoadBulletPrefabs()
    {
        if (this.bulletPrefabs != null) return;
        this.bulletPrefabs = GameObject.FindAnyObjectByType<BulletPrefabs>();
        Debug.Log(transform.name + ": LoadBulletPrefabs", gameObject);

        this.LoadBullet();
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

    protected virtual void HidePrefabs()
    {
        this.bullet.gameObject.SetActive(false);
    }
}
