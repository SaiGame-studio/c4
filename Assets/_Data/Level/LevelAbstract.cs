using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : SaiMonoBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [SerializeField] protected int maxLevel = 100;

    protected abstract int GetCurrentExp();
    protected abstract int DeductExp(int exp);

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    protected virtual void Leveling()
    {
        if(this.GetCurrentExp() >= this.GetNextLevelExp())
        {
            this.DeductExp(this.GetNextLevelExp());
            this.currentLevel++;
        }
    }

    protected virtual int GetNextLevelExp()
    {
        return this.currentLevel * 10;
    }
}
