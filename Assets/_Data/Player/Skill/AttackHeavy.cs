using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackHeavy()) return;
        
        Debug.Log("Heavy Attack");
    }
}
