using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected void Update()
    {
        this.Attacking();
    }

    protected override void Attacking()
    {
        if (InputManager.Instance.IsAttackLight()) Debug.Log("Light Attack");
    }
}
