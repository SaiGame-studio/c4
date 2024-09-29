using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtLevel : Text3DAbstact
{
    [SerializeField] protected TowerCtrl towerCtrl;

    protected virtual void FixedUpdate()
    {
        this.UpdateLevel();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }

    protected virtual void UpdateLevel()
    {
        this.textPro.text = this.towerCtrl.Level.CurrentLevel.ToString();
    }
}
