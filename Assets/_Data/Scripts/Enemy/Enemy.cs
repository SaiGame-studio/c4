using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 100;
    int maxHp = 100;
    float weight = 1;
    float minWeight = 1f;
    float maxWeight = 10f;
    bool isDead = false;
    bool isBoss = true;

    private void Reset()
    {
        this.InitData();
    }

    void OnEnable()
    {
        this.InitData();
    }

    public abstract string GetName();

    protected virtual void InitData()
    {
        this.weight = this.GetRandomWeight();
    }

    protected virtual float GetRandomWeight()
    {
        return Random.Range(this.minWeight, this.maxWeight);
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

    public virtual int GetMaxHp()
    {
        return this.maxHp;
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

