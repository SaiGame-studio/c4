using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandCtrl : WeaponAbtract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.0906f, 0.1009f, 0.0098f);
        transform.localRotation = Quaternion.Euler(-8.587f, -178.977f, 263.179f);
        transform.localScale = new Vector3(0.46083f, 0.46083f, 0.46083f);
    }
}
