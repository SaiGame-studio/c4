using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
    }

    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = GetComponent<Bullet>();
        Debug.Log(transform.name + ": LoadBullet", gameObject);
    }

}
