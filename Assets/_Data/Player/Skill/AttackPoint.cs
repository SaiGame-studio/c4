using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : SaiMonoBehaviour
{
    protected override void Reset()
    {
        base.Reset();
        transform.localPosition = new Vector3(0.046f, 0.507f, -0.01f);
    }
}
