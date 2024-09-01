using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{

    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObject = Instantiate(bulletPrefab);
        newObject.Despawn.SetSpawner(this);
        this.spawnCount++;
        this.UpdateName(bulletPrefab.transform, newObject.transform);
        return newObject;
    }

    public virtual Bullet Spawn(Bullet buletPrefab, Vector3 postion)
    {
        Bullet newBullet = this.Spawn(buletPrefab);
        newBullet.transform.position = postion;
        return newBullet;
    }
}
