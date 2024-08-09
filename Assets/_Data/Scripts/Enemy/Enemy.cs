using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 100;
    int maxHp = 100;
    float weight = 2.5f;
    bool isDead = true;
    bool isBoss = true;

    EnemyHead head1 = new EnemyHead();
    EnemyHeart heart = new EnemyHeart();

    void TestClass()
    {
        this.GetName();
    }

    protected abstract string GetName();

    int GetCurrentHp()
    {
        return this.currentHp;
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

