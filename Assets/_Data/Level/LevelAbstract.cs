using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : SaiMonoBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [SerializeField] protected int maxLevel = 100;
    [SerializeField] protected int nextLevelExp;

    protected abstract int GetCurrentExp();
    protected abstract bool DeductExp(int exp);

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    protected virtual void Leveling()
    {
        Debug.Log("Leveling");
        if (this.currentLevel >= this.maxLevel) return;
        if (this.GetCurrentExp() < this.GetNextLevelExp()) return;
        if (!this.DeductExp(this.GetNextLevelExp())) return;
        this.currentLevel++;
    }

    protected virtual int GetNextLevelExp()
    {
        return this.nextLevelExp = this.currentLevel * 15;
    }
}
