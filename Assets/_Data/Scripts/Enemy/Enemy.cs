using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 100;
    int maxHp = 100;
    float weight = 2.5f;
    bool isDead = false;
    bool isBoss = true;

    EnemyHead head1 = new EnemyHead();
    EnemyHeart heart = new EnemyHeart();
    
    public abstract string GetName();


    void TestClass()
    {
        this.GetName();
    }

    public virtual bool IsDead()
    {
        if (this.currentHp > 0) this.isDead = false;
        else this.isDead = true;

        return this.isDead;
    }

    public virtual int GetCurrentHp()
    {
        return this.currentHp;
    }

    public virtual void SetHp(int newHp)
    {
        this.currentHp = newHp;
    }

    float GetWeight()
    {
        return this.weight;
    }

    bool IsBoss()
    {
        return this.isBoss;
    }

    public void Moving()
    {
        // Toan Tu, Operator
        string logMessage = this.GetName() + ": Moving";
        Debug.Log(logMessage);
    }
}

