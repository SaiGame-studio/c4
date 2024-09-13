using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_hint : SaiMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(-23.38f, 1.295f, -20.865f);
        transform.localRotation = Quaternion.Euler(101.8f, 115.945f, 22.98399f);
    }
}
